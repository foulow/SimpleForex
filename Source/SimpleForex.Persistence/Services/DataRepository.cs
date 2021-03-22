using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleForex.Core.Contracts;
using AsyncOperation = System.Threading.Tasks.Task;

namespace SimpleForex.Persistence.Services
{
    public class DataRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity<int>
    {
        private readonly ApplicationDBContext _dBContext;

        public DataRepository(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public IUnitOfWork GetTransaction()
        {
            return new UnitOfWork(_dBContext);
        }

        #region Queries

        #region GET

        public TEntity Get(Func<TEntity, bool> query)
        {
            return _dBContext.Set<TEntity>().FirstOrDefault(query);
        }

        public Task<TEntity> GetAllAsync(Func<TEntity, bool> query)
        {
            return AsyncOperation.FromResult(Get(query));
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dBContext.Set<TEntity>();
        }

        public Task<IQueryable<TEntity>> GetAllAsync()
        {
            return AsyncOperation.FromResult(GetAll());
        }

        public List<TEntity> Query(Func<TEntity, bool> query)
        {
            return _dBContext.Set<TEntity>().Where(query).ToList();
        }

        public List<TResult> Query<TResult>(Func<TEntity, bool> query,
            Func<TEntity, TResult> select)
            where TResult : IEntity<int>
        {
            var result = _dBContext.Set<TEntity>()
                .Where(query)
                .Select(select)
                .ToList();

            return result;
        }

        public Task<List<TEntity>> QueryAsync(Func<TEntity, bool> query)
        {
            return AsyncOperation.FromResult(Query(query));
        }

        #endregion

        #region OPTIONS

        public bool Any(Func<TEntity, bool> query = null)
        {
            var result = (query != null) ?
                _dBContext.Set<TEntity>().Any(query) :
                _dBContext.Set<TEntity>().Any();

            return result;
        }

        public Task<bool> AnyAsync(Func<TEntity, bool> query = null)
        {
            return AsyncOperation.FromResult(Any(query));
        }

        #endregion

        #endregion

        #region Commands

        #region POST

        public void Add(TEntity entity)
        {
            _dBContext.Set<TEntity>().Add(entity);
        }

        public AsyncOperation AddAsync(TEntity entity)
        {
            return AsyncOperation.Run(() => Add(entity));
        }

        public void AddGroup(IEnumerable<TEntity> entities)
        {
            _dBContext.Set<TEntity>().AddRange(entities);
        }

        public AsyncOperation AddGroupAsync(IEnumerable<TEntity> entities)
        {
            return AsyncOperation.Run(() => AddGroup(entities));
        }

        #endregion


        #region DELETE

        public void Delete(TEntity entity)
        {
            var entityToDelete = this.Get(x => x.Id == entity.Id);

            _dBContext.Set<TEntity>().Remove(entityToDelete);
        }

        public AsyncOperation DeleteAsync(TEntity entity)
        {
            return AsyncOperation.Run(() => Delete(entity));
        }

        public void DeleteGroup(Func<TEntity, bool> query)
        {
            var entitiesToDelete = Query(query);
            _dBContext.Set<TEntity>().RemoveRange(entitiesToDelete);
        }

        public AsyncOperation DeleteGroupAsync(Func<TEntity, bool> query)
        {
            return AsyncOperation.Run(() => DeleteGroup(query));
        }

        #endregion


        #region PUT/PATCH

        public void Update(TEntity entity)
        {
            _dBContext.Set<TEntity>().Update(entity);
        }

        public AsyncOperation UpdateAsync(TEntity entity)
        {
            return AsyncOperation.Run(() => Update(entity));
        }

        public void UpdateGroup(TEntity entity, Func<TEntity, bool> query)
        {
            var entitiesToUpdate = Query(query);
            var updatedEntities = entitiesToUpdate.Select(x => UpdateGenericObject(x, entity));
            _dBContext.Set<TEntity>().UpdateRange(updatedEntities);
        }

        public AsyncOperation UpdateGroupAsync(TEntity entity, Func<TEntity, bool> query)
        {
            return AsyncOperation.Run(() => UpdateGroup(entity, query));
        }

        #endregion

        #endregion

        #region Auxiliary Methods

        private TEntity UpdateGenericObject(TEntity entityToUpdate, TEntity entityChanges)
        {
            var toUpdateProperties = entityToUpdate.GetType().GetProperties();
            var changedPropertyInfos = entityChanges.GetType().GetProperties();

            for (var i = 0; i < toUpdateProperties.Length; i++)
            {
                if (toUpdateProperties[i].Name == nameof(entityChanges.Id))
                    continue;
                toUpdateProperties[i].SetValue(entityToUpdate,
                    changedPropertyInfos[i].GetValue(entityChanges));
            }

            return entityToUpdate;
        }

        #endregion
    }
}
