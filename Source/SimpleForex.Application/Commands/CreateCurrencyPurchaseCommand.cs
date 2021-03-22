using System;
using System.Linq;
using Ardalis.GuardClauses;
using AutoMapper;
using SimpleForex.Application.DTOs;
using SimpleForex.Core.Contracts;
using SimpleForex.Core.Entities;

namespace SimpleForex.Application.Commands
{
    public class CreateCurrencyPurchaseCommand : ICommandWithParam<(string, CurrencyPurchaseCreateDTO)>
    {
        private readonly ISupportedCurrencies _supportedCurrencies;
        private readonly IRepository<CurrencyPurchase> _repository;
        private readonly IMapper _mapper;

        public CreateCurrencyPurchaseCommand(ISupportedCurrencies supportedCurrencies, IRepository<CurrencyPurchase> repository, IMapper mapper)
        {
            Guard.Against.Null(supportedCurrencies, nameof(supportedCurrencies));
            Guard.Against.Null(repository, nameof(repository));
            Guard.Against.Null(mapper, nameof(mapper));

            _supportedCurrencies = supportedCurrencies;
            _repository = repository;
            _mapper = mapper;
        }

        public void Execute((string, CurrencyPurchaseCreateDTO) tupple)
        {
            (string code, CurrencyPurchaseCreateDTO model) = tupple;

            Guard.Against.NullOrEmpty(code, nameof(code));
            Guard.Against.Null(model, nameof(model));

            var newCurrencyPurchase = _mapper.Map<CurrencyPurchase>(model);

            var transaction = _repository.GetTransaction();

            var transactions = _repository
                .Query(cp => cp.UserId == newCurrencyPurchase.UserId &&
                             cp.CurrencyId == model.CurrencyId &&
                             (DateTime.Now.Month == cp.MadeOn.Month &&
                             DateTime.Now.Year == cp.MadeOn.Year))
                .ToList();

            var totalPurchased = transactions.Sum(cp => cp.Amount);
            var purchaseLimit = _supportedCurrencies.GetPurchaseLimit(code);
            if (totalPurchased != 0)
            {
                if ((totalPurchased + model.Amount) > purchaseLimit)
                    throw new MethodAccessException($"The amount of currency been purchased is greater thant the limit set for this currency. Available: $ {purchaseLimit - totalPurchased}");
            }
            else if (model.Amount > purchaseLimit)
            {
                throw new MethodAccessException($"The amount of currency been purchased is greater than the limit set for this currency. Execpected: $ {purchaseLimit}");
            }


            _repository.Add(newCurrencyPurchase);

            transaction.Commit();
        }
    }
}
