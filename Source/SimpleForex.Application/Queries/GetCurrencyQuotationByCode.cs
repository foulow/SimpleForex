using System;
using Ardalis.GuardClauses;
using AutoMapper;
using Serilog;
using SimpleForex.Application.Collections;
using SimpleForex.Application.DTOs;
using SimpleForex.Core.Contracts;
using SimpleForex.Core.Contracts.Factories;
using SimpleForex.Core.Entities;

namespace SimpleForex.Application.Queries
{
    public class GetCurrencyQuotationByCode : BaseQuery<string, CurrencyQuotationDTO>
    {
        private readonly IRepository<Currency> _repository;
        private readonly IServiceFactory _serviceFactory;
        private readonly IMapper _mapper;

        public GetCurrencyQuotationByCode(IRepository<Currency> repository, IServiceFactory serviceFactory, IMapper mapper)
        {
            Guard.Against.Null(repository, nameof(repository));
            Guard.Against.Null(serviceFactory, nameof(serviceFactory));
            Guard.Against.Null(mapper, nameof(mapper));

            _repository = repository;
            _serviceFactory = serviceFactory;
            _mapper = mapper;
        }

        public override CurrencyQuotationDTO Execute(string code)
        {
            Guard.Against.Null(code, nameof(code));

            // Ensures the currency is supported.
            Currency currency;
            if (!SuppotedCurrenciesServices.Services.ContainsKey(code))
                throw new ArgumentException("The currency provided is not supported.");

            // Gets the currency id from the database.
            try
            {
                currency = _repository.Get(c => c.Code == code);
                Guard.Against.Null(currency, nameof(currency));
            }
            catch
            {
                Log.Error($"The Currency repository could not find the currency code: {code}, when it should.");
                throw new ArgumentException("The currency provided is not supported.");
            }

            // Gets the currency purchase price.
            var serviceName = SuppotedCurrenciesServices.Services[code];
            var quotationService = _serviceFactory
                .MakeService<CurrencyQuotationDTO>(serviceName);
            var quotation = quotationService.RunService(code);
            quotation.Id = currency.Id;

            // QUIT_PATH: When the currency is receved from a service other than `QuotationWithURLService`.
            if (serviceName != "QuotationWithURLService")
                quotation.Code = code;

            return quotation;
        }
    }
}
