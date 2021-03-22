using System;
using System.Collections.Generic;

namespace SimpleForex.Application.Collections
{

    /// <summary>
    /// Contains a list of currencies and their attributes.
    /// </summary>
    public static class SupportedCurrenciesURLs
    {
        /// <summary>
        /// Holds a list of service's url to get their updated-on, sell and purchase price.
        /// </summary>
        public static readonly Dictionary<string, string> URLs = new Dictionary<string, string>()
        {
            #region Forex resvice URLs for the Argentinian Peso.
            [Enum.GetName(typeof(SupportedCurrenciesCodes), SupportedCurrenciesCodes.USD_ARS)] = "http://www.bancoprovincia.com.ar/Principal/Dolar",

            // TODO: Include external service url
            [Enum.GetName(typeof(SupportedCurrenciesCodes), SupportedCurrenciesCodes.BRL_ARS)] = "",

            // TODO: Develop a CAD_ARSQuotationService implementing the BaseService and uncomment line below to enable the API to accept Canidian Dollars.
            // TODO: Include external service url.
            // [Enum.GetName(typeof(SupportedCurrencies), SupportedCurrencies.CAD_ARS)] = "",
            #endregion
        };
    }
}
