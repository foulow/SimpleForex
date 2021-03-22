using System;
using Microsoft.Extensions.Configuration;
using SimpleForex.Core.Contracts;

namespace SimpleForex.Core.Collections
{
    /// <summary>
    /// List of supported currencies.
    /// </summary>
    public enum SupportedCurrenciesCodes
    {
        USD_ARS,
        BRL_ARS,
        // TODO: Develop a CAD_ARSQuotationService implementing the BaseService and uncomment line below to enable the API to accept Canidian Dollars.
        // CAD_ARS,
    }

    /// <summary>
    /// Accesses the appsettings.json to retrive and validated the currencies configutations.
    /// </summary>
    public class SupportedCurrencies : ISupportedCurrencies
    {
        private readonly IConfiguration _configuration;

        public IConfigurationSection Currencies { get; }

        /// <summary>
        /// Main constructor.
        /// </summary>
        /// <param name="configuration"></param>
        public SupportedCurrencies(IConfiguration configuration)
        {
            _configuration = configuration;
            Currencies = _configuration.GetSection("SupportedCurrencies");
        }

        public bool IsSupported(string code)
        {
            return Currencies.GetSection(code).Exists();
        }

        public void EnsuredSupported(string code)
        {
            var currency = Currencies.GetSection(code);

            if (!currency.Exists())
                throw new ArgumentException("The currency provided is not supported.");
        }

        public string GetCurrencyUrl(string code)
        {
            EnsuredSupported(code);

            string result = Currencies.GetSection(code)["URL"];

            return result;
        }

        public decimal GetPurchaseLimit(string code)
        {
            EnsuredSupported(code);

            var result = decimal.Parse(Currencies.GetSection(code)["PurchaseLimit"]);

            return result;
        }
    }
}
