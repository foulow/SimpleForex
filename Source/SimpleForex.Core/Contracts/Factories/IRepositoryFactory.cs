using System;

namespace SimpleForex.Core.Contracts.Factories
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity> MakeRepository<TEntity>() where TEntity : class, IEntity<int>;
    }
}
