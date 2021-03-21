using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleForex.Core.Entities
{
    /// <summary>
    /// Represents a purchase transaction of a foraign monetary unit payed with a national one.
    /// </summary>
    public class CurrencyPurchase : BaseEntity<int>
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
        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }
        public int CurrencyId { get; set; }
    }
}
