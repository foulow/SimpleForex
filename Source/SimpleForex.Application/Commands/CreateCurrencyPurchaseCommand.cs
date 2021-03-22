using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using AutoMapper;
using SimpleForex.Application.DTOs;
using SimpleForex.Core.Contracts;
using SimpleForex.Core.Entities;

namespace SimpleForex.Application.Commands
{
    public class CreateCurrencyPurchaseCommand : ICommandWithParam<CurrencyPurchaseDTO>
    {
        private readonly IRepository<CurrencyPurchase> _repository;
        private readonly IMapper _mapper;

        public CreateCurrencyPurchaseCommand(IRepository<CurrencyPurchase> repository, IMapper mapper)
        {
            Guard.Against.Null(repository, nameof(repository));
            Guard.Against.Null(mapper, nameof(mapper));

            _repository = repository;
            _mapper = mapper;
        }

        public void Execute(CurrencyPurchaseDTO model)
        {
            Guard.Against.Null(model, nameof(model));

            var newCurrencyPurchase = _mapper.Map<CurrencyPurchase>(model);

            var transaction = _repository.GetTransaction();

            var transactions = _repository
                .Query(cp => cp.UserId == newCurrencyPurchase.UserId)
                .GroupBy(cp => cp.CurrencyId,
                    (id, currencyPurchases) => new List<CurrencyPurchase>(currencyPurchases));

            _repository.Add(newCurrencyPurchase);

            transaction.Commit();
        }
    }
}
