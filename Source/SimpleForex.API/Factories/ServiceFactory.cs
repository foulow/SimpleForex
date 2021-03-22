using System;
using System.Reflection;
using Ardalis.GuardClauses;
using SimpleForex.Core.Contracts;
using SimpleForex.Core.Contracts.Factories;
using SimpleForex.Core.Contracts.Services;

namespace SimpleForex.API.Factories
{
    /// <summary>
    /// Create an instance of an service.
    /// </summary>
    public class ServiceFactory : IServiceFactory
    {
        protected readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="serviceProvider">IoC container.</param>
        public ServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc/>
        public IService<TEntity> MakeService<TEntity>(string instanceName) where TEntity : IEntity<int>
        {
            Guard.Against.NullOrEmpty(instanceName, nameof(instanceName));

            var assembly = Assembly.Load("SimpleForex.Application");
            var _type = assembly.GetType("SimpleForex.Application.Services." + instanceName);
            var result = _serviceProvider.GetService(_type);
            var service = result as IService<TEntity>;

            return service;
        }
    }
}
