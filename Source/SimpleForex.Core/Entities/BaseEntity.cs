using System;

namespace SimpleForex.Core.Entities
{
    /// <summary>
    /// Represents a entity with the minimum information for the database.
    /// </summary>
    /// <typeparam name="T">The entities id type.</typeparam>
    public abstract class BaseEntity<T> : Contracts.IEntity<T>
    {
        /// <inheritdoc/>
        public T Id { get; set; }

        /// <inheritdoc/>
        public T CreatedBy { get; set; }

        /// <inheritdoc/>
        public DateTime CreatedDate { get; set; }

        /// <inheritdoc/>
        public T UpdatedBy { get; set; }

        /// <inheritdoc/>
        public DateTime UpdatedDate { get; set; }

        /// <inheritdoc/>
        public string DeleteFlag { get; set; }
    }
}
