namespace SimpleForex.Core.Contracts
{
    /// <summary>
    /// Create an instance of an async query.
    /// </summary>
    public interface IQueryFactory
    {
        /// <summary>
        /// Get an instance of an async query.
        /// </summary>
        /// <typeparam name="TQuery">Query type.</typeparam>
        TQuery MakeQuery<TQuery>() where TQuery : IQueryBase;
    }
}
