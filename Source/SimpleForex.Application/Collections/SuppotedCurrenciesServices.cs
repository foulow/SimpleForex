using System;
using System.Collections.Generic;
using SimpleForex.Application.Services;
using SimpleForex.Core.Collections;

namespace SimpleForex.Application.Collections
{
    /// <summary>
    /// 
    /// </summary>
    public class SuppotedCurrenciesServices
    {
        public static readonly Dictionary<string, string> Services = new Dictionary<string, string>()
        {
            #region Forex resvice URLs for the Argentinian Peso.
            [Enum.GetName(typeof(SupportedCurrenciesCodes), SupportedCurrenciesCodes.USD_ARS)] =
            nameof(QuotationWithURLService),

            // TODO: Include external service url
            [Enum.GetName(typeof(SupportedCurrenciesCodes), SupportedCurrenciesCodes.BRL_ARS)] =
            nameof(BRL_ARSQuotationService),

            // TODO: Develop a CAD_ARSQuotationService implementing the BaseService and uncomment line below to enable the API to accept Canidian Dollars.
            // [Enum.GetName(typeof(SupportedCurrencies), SupportedCurrencies.CAD_ARS)] =
            // nameof(CAD_ARSQuotationService),
            #endregion
        };
    }
}
