using System;
using System.Threading.Tasks;

namespace SimpleForex.Core.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class, IEntity<int>;
        void Commit();
        Task CommitAsync();
    }
}
