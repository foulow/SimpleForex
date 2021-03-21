using System;
using System.Collections.Generic;
using Ardalis.GuardClauses;
using AutoMapper;
using SimpleForex.Application.DTOs;
using SimpleForex.Core.Contracts;
using SimpleForex.Core.Entities;

namespace SimpleForex.Application.Queries
{
    public class GetCurrencyPurchasesQuery : BaseQuery<Func<CurrencyPurchase, bool>, List<CurrencyPurchaseDTO>>
    {
        private readonly IRepository<CurrencyPurchase> _repository;
        private readonly IMapper _mapper;

        public GetCurrencyPurchasesQuery(IRepository<CurrencyPurchase> repository, IMapper mapper)
        {
            Guard.Against.Null(repository, nameof(repository));
            Guard.Against.Null(mapper, nameof(mapper));

            _repository = repository;
            _mapper = mapper;
        }

        public override List<CurrencyPurchaseDTO> Execute(Func<CurrencyPurchase, bool> query)
        {
            Guard.Against.Null(query, nameof(query));

            var addresses = _repository.Query(query);

            var addressesDto = _mapper.Map<List<CurrencyPurchaseDTO>>(addresses);

            return addressesDto;
        }
    }
}
