using Ardalis.GuardClauses;
using AutoMapper;
using SimpleForex.Application.DTOs;
using SimpleForex.Core.Contracts;
using SimpleForex.Core.Entities;

namespace SimpleForex.Application.Queries
{
    public class GetCurrencyByCode : BaseQuery<string, CurrencyDTO>
    {
        private readonly IRepository<Currency> _repository;
        private readonly IMapper _mapper;

        public GetCurrencyByCode(IRepository<Currency> repository, IMapper mapper)
        {
            Guard.Against.Null(repository, nameof(repository));
            Guard.Against.Null(mapper, nameof(mapper));

            _repository = repository;
            _mapper = mapper;
        }

        public override CurrencyDTO Execute(string code)
        {
            Guard.Against.Null(code, nameof(code));

            var client = _repository.Get(c => c.Code == code);

            var clientDto = _mapper.Map<CurrencyDTO>(client);

            return clientDto;
        }
    }
}
