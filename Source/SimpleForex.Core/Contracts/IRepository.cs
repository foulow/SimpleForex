using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SimpleForex.Core.Contracts
{
    public interface IRepository<TEntity> where TEntity : class, IEntity<Guid>
    {
        IUnitOfWork GetTransaction();

        #region GET

        TEntity Get(Func<TEntity, bool> query);
        Task<TEntity> GetAllAsync(Func<TEntity, bool> query);
        IQueryable<TEntity> GetAll();
        Task<IQueryable<TEntity>> GetAllAsync();
        List<TEntity> Query(Func<TEntity, bool> query);
        List<TResult> Query<TResult>(Func<TEntity, bool> query,
            Func<TEntity, TResult> select)
            where TResult : IEntity<Guid>;
        Task<List<TEntity>> QueryAsync(Func<TEntity, bool> query);

        bool Any(Func<TEntity, bool> query = null);
        Task<bool> AnyAsync(Func<TEntity, bool> query = null);

        #endregion

        #region POST

        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        void AddGroup(IEnumerable<TEntity> entities);
        Task AddGroupAsync(IEnumerable<TEntity> entities);

        #endregion

        #region PUT/PATCH

        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);
        void UpdateGroup(TEntity entity, Func<TEntity, bool> query);
        Task UpdateGroupAsync(TEntity entity, Func<TEntity, bool> query);

        #endregion

        #region DELETE

        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity);
        void DeleteGroup(Func<TEntity, bool> query);
        Task DeleteGroupAsync(Func<TEntity, bool> query);

        #endregion
    }
}
