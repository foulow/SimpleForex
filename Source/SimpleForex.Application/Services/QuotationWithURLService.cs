using System;
using System.Net.Http;
using Ardalis.GuardClauses;
using Newtonsoft.Json.Linq;
using SimpleForex.Application.DTOs;
using SimpleForex.Core.Collections;
using SimpleForex.Core.Contracts;

namespace SimpleForex.Application.Services
{
    /// <summary>
    /// Service to get a currecny quotation using an externar API service or URL.
    /// </summary>
    public class QuotationWithURLService : BaseService<string, CurrencyQuotationDTO>
    {
        private readonly ISupportedCurrencies _supportedCurrencies;
        private string _currencyCode;
        private string _sourceURL;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="supportedCurrencies">The </param>
        public QuotationWithURLService(ISupportedCurrencies supportedCurrencies)
        {
            _supportedCurrencies = supportedCurrencies;
        }

        /// <inheritdoc/>
        public override CurrencyQuotationDTO RunService(string currencyCode)
        {
            _currencyCode = currencyCode;
            Guard.Against.NullOrEmpty(_currencyCode, nameof(_currencyCode));

            _sourceURL = _supportedCurrencies.GetCurrencyUrl(_currencyCode);
            Guard.Against.NullOrEmpty(_sourceURL, nameof(_sourceURL));
            Guard.Against.InvalidFormat(_sourceURL, nameof(_sourceURL), Regexs.URLRegex);

            var result = GetCurrencyQuotationWithURL();
            return result;
        }

        /// <summary>
        /// Helper function to get the currency quotation.
        /// </summary>
        /// <returns>A CurrencyQuotationDTO instance.</returns>
        private CurrencyQuotationDTO GetCurrencyQuotationWithURL()
        {
            var client = new HttpClient();

            HttpResponseMessage response = client.GetAsync(_sourceURL).Result;
            response.EnsureSuccessStatusCode();

            var responseString = response.Content.ReadAsStringAsync().Result;

            var responseObject = JObject.Parse(responseString).ToObject<string[]>();

            var result = new CurrencyQuotationDTO
            {
                Code = _currencyCode,
                SellPrice = decimal.Parse(responseObject[0]),
                PurchasePrice = decimal.Parse(responseObject[1]),
                UpdateOn = DateTime.Today.ToString("dd/MM/yyyy ") + DateTime.Now.ToString("hh:mm")
            };

            return result;
        }
    }
}
