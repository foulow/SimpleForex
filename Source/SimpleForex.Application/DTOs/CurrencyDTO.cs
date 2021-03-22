using SimpleForex.Core.Entities;

namespace SimpleForex.Application.DTOs
{
    /// <summary>
    /// Represents a DTO (Data Transfer Object) for the DB entity Currency.
    /// </summary>
    public class CurrencyDTO : BaseEntity<int>
    {
        /// <summary>
        /// Holds the International Currencies' code wich represents the monetary units been exchanged.
        /// For example:
        ///     the currency's code for the American Dollar (USD) to Argentinian Peso (ARS) would be (USD_ARS)
        /// </summary>
        public string Code { get; set; }
    }
}
