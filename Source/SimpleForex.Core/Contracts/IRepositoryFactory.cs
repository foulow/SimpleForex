using System;

namespace SimpleForex.Core.Contracts
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity> MakeRepository<TEntity>() where TEntity : class, IEntity<int>;
    }
}
