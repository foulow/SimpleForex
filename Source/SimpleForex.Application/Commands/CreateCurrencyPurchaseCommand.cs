using Ardalis.GuardClauses;
using AutoMapper;
using SimpleForex.Application.DTOs;
using SimpleForex.Core.Contracts;
using SimpleForex.Core.Entities;

namespace SimpleForex.Application.Commands
{
    public class CreateCurrencyPurchaseCommand : ICommand<CurrencyDTO>
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

        public void Execute(CurrencyDTO model)
        {
            Guard.Against.Null(model, nameof(model));

            var newCurrencyPurchase = _mapper.Map<CurrencyPurchase>(model);

            var transaction = _repository.GetTransaction();

            _repository.Add(newCurrencyPurchase);

            transaction.Commit();
        }
    }
}
