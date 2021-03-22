namespace SimpleForex.Core.Contracts.Services
{

    /// <summary>
    /// Represents a base service interface.
    /// </summary>
    /// <typeparam name="TResult">Service result.</typeparam>
    public interface IService<TResult> : IServiceBase where TResult : IEntity<int>
    {
        /// <summary>
        /// Runs the service returning a specified result when it finishes.
        /// </summary>
        /// <returns><typeparamref name="TResult"/></returns>
        TResult RunService(string param);
    }
}
