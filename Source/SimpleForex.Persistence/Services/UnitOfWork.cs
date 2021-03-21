using System.Threading.Tasks;
using SimpleForex.Core.Contracts;

namespace SimpleForex.Persistence.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _dBContext;

        public UnitOfWork(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        #region Interface Methods

        public void Commit()
        {
            _dBContext.SaveChanges();
        }

        public Task CommitAsync()
        {
            return _dBContext.SaveChangesAsync();
        }

        public IRepository<T> GetRepository<T>() where T : class, IEntity<int>
        {
            return new DataRepository<T>(_dBContext);
        }

        #endregion
    }
}
