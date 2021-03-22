using SimpleForex.Core.Contracts;

namespace SimpleForex.Core.Entities
{
    /// <summary>
    /// Represents a entity with the minimum information for the database.
    /// </summary>
    /// <typeparam name="T">The entities id type.</typeparam>
    public abstract class BaseEntity<T> : IEntity<T>
    {
        /// <inheritdoc/>
        public T Id { get; set; }
    }
}
