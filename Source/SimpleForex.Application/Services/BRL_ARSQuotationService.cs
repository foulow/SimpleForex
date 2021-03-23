using System;
using Ardalis.GuardClauses;
using SimpleForex.Application.DTOs;
using SimpleForex.Core.Collections;
using SimpleForex.Core.Contracts;
using SimpleForex.Core.Contracts.Factories;

namespace SimpleForex.Application.Services
{
    public class BRL_ARSQuotationService : BaseService<CurrencyQuotationDTO>
    {
        private readonly ISupportedCurrencies _supportedCurrencies;
        private readonly IServiceFactory _serviceFactory;
        private string _currencyCode;
        private string _sourceURL;

        public BRL_ARSQuotationService(ISupportedCurrencies supportedCurrencies, IServiceFactory serviceFactory)
        {
            _supportedCurrencies = supportedCurrencies;
            _serviceFactory = serviceFactory;
        }

        /// <inheritdoc/>
        public override CurrencyQuotationDTO RunService(string currencyCode)
        {
            _currencyCode = currencyCode;
            Guard.Against.NullOrEmpty(currencyCode, nameof(currencyCode));

            if (_currencyCode == Enum.GetName(typeof(SupportedCurrenciesCodes), SupportedCurrenciesCodes.BRL_ARS))
            {
                var USD_ARSCode = Enum.GetName(typeof(SupportedCurrenciesCodes), SupportedCurrenciesCodes.USD_ARS);
                Guard.Against.NullOrEmpty(currencyCode, nameof(USD_ARSCode));

                _sourceURL = _supportedCurrencies.GetCurrencyUrl(USD_ARSCode);
                Guard.Against.NullOrEmpty(_sourceURL, nameof(_sourceURL));
                Guard.Against.InvalidFormat(_sourceURL, nameof(_sourceURL), Regexs.URLRegex);

                var quotationWithURL = _serviceFactory.MakeService<CurrencyQuotationDTO>(nameof(QuotationWithURLService));
                var USD_ARSQuotation = quotationWithURL.RunService(USD_ARSCode) as CurrencyQuotationDTO;

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
                UpdatedOn = quotation.UpdatedOn
            };

            return result;
        }
    }
}
