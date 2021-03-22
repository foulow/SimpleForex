using System;
using Ardalis.GuardClauses;
using AutoMapper;
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
            Guard.Against.Null(mapper, nameof(mapper));

            _repository = repository;
            _serviceFactory = serviceFactory;
            _mapper = mapper;
        }

        public override CurrencyQuotationDTO Execute(string code)
        {
            Guard.Against.Null(code, nameof(code));

            if (!SuppotedCurrenciesServices.Services.ContainsKey(code))
                throw new ArgumentException("The currency provided is not supported.");

            var quotationService = _serviceFactory
                .MakeService(SuppotedCurrenciesServices.Services[code]);

            var quotation = quotationService.RunService(code) as CurrencyQuotationDTO;

            return quotation;
        }
    }
}
