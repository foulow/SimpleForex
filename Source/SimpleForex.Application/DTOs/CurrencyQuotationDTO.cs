using SimpleForex.Core.Entities;

namespace SimpleForex.Application.DTOs
{
    /// <summary>
    /// Represents a currency quotation with the purchase, sell and updated-on values
    /// </summary>
    public class CurrencyQuotationDTO : BaseEntity<int>
    {
        /// <summary>
        /// Holds the International Currencies' code wich represents the monetary units been exchanged.
        /// For example:
        ///     the currency's code for the American Dollar (USD) to Argentinian Peso (ARS) would be (USD_ARS)
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///
        /// </summary>
        public decimal SellPrice { get; set; }

        /// <summary>
        ///
        /// </summary>
        public decimal PurchasePrice { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string UpdatedOn { get; set; }
    }
}
