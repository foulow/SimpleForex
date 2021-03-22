namespace SimpleForex.Core.Contracts
{
    /// <summary>
    /// Represents a entity with the minimum information for the database.
    /// </summary>
    /// <typeparam name="T">The entities id type.</typeparam>
    public interface IEntity<T>
    {
        /// <summary>
        /// The entity unique identifier.
        /// </summary>
        T Id { get; set; }
    }
}
