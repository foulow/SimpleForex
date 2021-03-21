namespace SimpleForex.Core.Entities
{
    /// <summary>
    /// Represents a transaction type between two monetary units.
    /// </summary>
    public class Currency : BaseEntity<int>
    {
        /// <summary>
        /// Holds the International Currencies' code wich represents the monetary units been exchanged.
        /// For example:
        ///     the currency's code for the American Dollar (USD) to Argentinan Peso (ARS) would be (USD-ARS)
        /// </summary>
        public string Code { get; set; }
    }
}
