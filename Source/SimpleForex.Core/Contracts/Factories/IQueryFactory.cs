namespace SimpleForex.Core.Contracts.Factories
{
    /// <summary>
    /// Create an instance of a query.
    /// </summary>
    public interface IQueryFactory
    {
        /// <summary>
        /// Get an instance of a query.
        /// </summary>
        /// <typeparam name="TQuery">Query type.</typeparam>
        TQuery MakeQuery<TQuery>() where TQuery : IQueryBase;
    }
}
