using SimpleForex.Core.Contracts;
using SimpleForex.Core.Contracts.Services;

namespace SimpleForex.Application.Services
{
    /// <summary>
    /// Represents a base service abstract class.
    /// </summary>
    /// <typeparam name="TResult">Service returned result type.</typeparam>
    public abstract class BaseService<TResult> : IService<TResult>
        where TResult : IEntity<int>
    {
        /// <inheritdoc/>
        public abstract TResult RunService(string param);
    }
}
