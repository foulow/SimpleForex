using System;
using SimpleForex.Core.Entities;

namespace SimpleForex.Application.DTOs
{
    /// <summary>
    /// Represents a DTO (Data Transfer Object) for the DB entity CurrencyPurchase.
    /// </summary>
    public class CurrencyPurchaseDTO : BaseEntity<int>
    {
        /// <summary>
        /// The Currency's foraign unit/s purchased by the User.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// The full date and time the transaction was completed.
        /// </summary>
        public DateTime MadeOn { get; set; }

        /// <summary>
        /// The User's id. (Entity not stored on the DB).
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The Currency's primary key as a foreign key.
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// The Currency's instace related with this purchase. 
        /// </summary>
        public virtual CurrencyDTO Currency { get; set; }
    }
}
