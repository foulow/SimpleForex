using System;
using Ardalis.GuardClauses;
using SimpleForex.Application.Collections;
using SimpleForex.Application.DTOs;

namespace SimpleForex.Application.Services
{
    public class BRL_ARSQuotationService : BaseService<string, CurrencyQuotationDTO>
    {
        private string _currencyCode;
        private string _sourceURL;

        /// <inheritdoc/>
        public override CurrencyQuotationDTO RunService(string currencyCode)
        {
            _currencyCode = currencyCode;
            Guard.Against.NullOrEmpty(currencyCode, nameof(currencyCode));

            if (_currencyCode == Enum.GetName(typeof(SupportedCurrenciesCodes), SupportedCurrenciesCodes.BRL_ARS))
            {
                var USD_ARSCode = Enum.GetName(typeof(SupportedCurrenciesCodes), SupportedCurrenciesCodes.USD_ARS);
                Guard.Against.NullOrEmpty(currencyCode, nameof(USD_ARSCode));

                _sourceURL = SupportedCurrenciesURLs.URLs[USD_ARSCode];
                Guard.Against.NullOrEmpty(_sourceURL, nameof(_sourceURL));
                Guard.Against.InvalidFormat(_sourceURL, nameof(_sourceURL), Regexs.URLRegex);

                var quotationWithURL = new QuotationWithURLService();
                var USD_ARSQuotation = quotationWithURL.RunService(USD_ARSCode);

                var resutl = GetCurrencyQuotationBaseOnOther(USD_ARSQuotation);
                return resutl;
            }
            else
            {
                throw new ArgumentException("The currency code provided is not supported for this service.");
            }
        }

        /// <summary>
        /// Helper function to get the currency quotation.
        /// </summary>
        /// <returns>A CurrencyQuotationDTO instance.</returns>
        private CurrencyQuotationDTO GetCurrencyQuotationBaseOnOther(CurrencyQuotationDTO quotation)
        {
            var result = new CurrencyQuotationDTO
            {
                Code = quotation.Code,
                SellPrice = quotation.SellPrice / 4m,
                PurchasePrice = quotation.PurchasePrice / 4m,
                UpdateOn = quotation.UpdateOn
            };

            return result;
        }
    }
}
