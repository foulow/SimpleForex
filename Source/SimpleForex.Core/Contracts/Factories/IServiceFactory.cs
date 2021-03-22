using SimpleForex.Core.Contracts.Services;

namespace SimpleForex.Core.Contracts.Factories
{
    /// <summary>
    /// Create an instance of a service.
    /// </summary>
    public interface IServiceFactory
    {

        /// <summary>
        /// Makes an instance of a service.
        /// </summary>
        /// <param name="instanceName">The name of the class to be instanciated.</param>
        /// <returns>An IService instance.</returns>
        IService<TEntity> MakeService<TEntity>(string instanceName) where TEntity : IEntity<int>;
    }
}
