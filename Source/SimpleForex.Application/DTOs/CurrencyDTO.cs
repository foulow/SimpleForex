namespace SimpleForex.Application.DTOs
{
    /// <summary>
    /// Represents a DTO (Data Transfer Object) for the DB entity Currency.
    /// </summary>
    public class CurrencyDTO
    {
        /// <summary>
        /// The entity unique identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Holds the International Currencies' code wich represents the monetary units been exchanged.
        /// For example:
        ///     the currency's code for the American Dollar (USD) to Argentinan Peso (ARS) would be (USD_ARS)
        /// </summary>
        public string Code { get; set; }
    }
}
