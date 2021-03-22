using System;
using Microsoft.Extensions.DependencyInjection;
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
        public IService<string, IEntity<int>> MakeService(string instanceName)
        {
            var result = _serviceProvider.GetRequiredService(Type.GetType(instanceName));

            return result as IService<string, IEntity<int>>;
        }
    }
}
