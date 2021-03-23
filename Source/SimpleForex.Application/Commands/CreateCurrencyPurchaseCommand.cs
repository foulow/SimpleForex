using System;
using System.Linq;
using Ardalis.GuardClauses;
using AutoMapper;
using SimpleForex.Application.Collections;
using SimpleForex.Application.DTOs;
using SimpleForex.Core.Contracts;
using SimpleForex.Core.Contracts.Factories;
using SimpleForex.Core.Entities;

namespace SimpleForex.Application.Commands
{
    public class CreateCurrencyPurchaseCommand : ICommandWithParam<(string, CurrencyPurchaseCreateDTO)>
    {
        private readonly ISupportedCurrencies _supportedCurrencies;
        private readonly IRepository<CurrencyPurchase> _repository;
        private readonly IServiceFactory _serviceFactory;
        private readonly IMapper _mapper;

        public CreateCurrencyPurchaseCommand(ISupportedCurrencies supportedCurrencies, IRepository<CurrencyPurchase> repository, IServiceFactory serviceFactory, IMapper mapper)
        {
            Guard.Against.Null(supportedCurrencies, nameof(supportedCurrencies));
            Guard.Against.Null(repository, nameof(repository));
            Guard.Against.Null(serviceFactory, nameof(serviceFactory));
            Guard.Against.Null(mapper, nameof(mapper));

            _supportedCurrencies = supportedCurrencies;
            _repository = repository;
            _serviceFactory = serviceFactory;
            _mapper = mapper;
        }

        public void Execute((string, CurrencyPurchaseCreateDTO) tupple)
        {
            (string code, CurrencyPurchaseCreateDTO model) = tupple;

            Guard.Against.NullOrEmpty(code, nameof(code));
            Guard.Against.Null(model, nameof(model));

            // Ensures the currency is supported.
            if (!SuppotedCurrenciesServices.Services.ContainsKey(code))
                throw new ArgumentException("The currency provided is not supported.");

            // Generates a transaction and a new CurrencyPurchase instance.
            var transaction = _repository.GetTransaction();
            var newCurrencyPurchase = _mapper.Map<CurrencyPurchase>(model);

            // Gets the purchases and the total amount purchased for the selected currency and user.
            var purchaseList = _repository
                .Query(cp => cp.UserId == newCurrencyPurchase.UserId &&
                             cp.CurrencyId == model.CurrencyId &&
                             (DateTime.Now.Month == cp.MadeOn.Month &&
                             DateTime.Now.Year == cp.MadeOn.Year))
                .ToList();
            var totalPurchased = purchaseList.Sum(cp => cp.Amount);
            var purchaseLimit = _supportedCurrencies.GetPurchaseLimit(code);

            // Gets the currency purchase price and transform the user's currency amount input to the currency amount to be purchased.
            var serviceName = SuppotedCurrenciesServices.Services[code];
            var quotationService = _serviceFactory
                .MakeService<CurrencyQuotationDTO>(serviceName);
            var quotation = quotationService.RunService(code);
            var toBePurchase = quotation.PurchasePrice / model.Amount;

            // Validates the user has not pass or will pass the limit set for the currency been purchased and updates the currency amount.
            if (totalPurchased != 0)
            {
                if ((totalPurchased + toBePurchase) > purchaseLimit)
                    throw new MethodAccessException($"The amount of currency been purchased is greater thant the limit set for this currency. Available: $ {purchaseLimit - totalPurchased}");
            }
            else if (toBePurchase > purchaseLimit)
            {
                throw new MethodAccessException($"The amount of currency been purchased is greater than the limit set for this currency. Execpected: $ {purchaseLimit}");
            }
            newCurrencyPurchase.Amount = toBePurchase;

            // Adds the new CurrencyPurchase and commits it to the database.
            _repository.Add(newCurrencyPurchase);
            transaction.Commit();
        }
    }
}
