namespace SimpleForex.Core.Contracts.Queries
{
    /// <summary>
    /// Represents an async query.
    /// </summary>
    /// <typeparam name="TQuery">Query options.</typeparam>
    /// <typeparam name="TResult">Query result.</typeparam>
    public interface IQuery<TQuery, TResult> : IQueryBase, System.Windows.Input.ICommand
    {
        /// <summary>
        /// Execute the query.
        /// </summary>
        /// <param name="query">Nullable parameter.</param>
        /// <returns><typeparamref name="TResult"/></returns>
        TResult Execute(TQuery query);
    }
}
