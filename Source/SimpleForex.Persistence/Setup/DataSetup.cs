using System;
using System.Collections.Generic;
using SimpleForex.Core.Collections;
using SimpleForex.Core.Entities;

namespace SimpleForex.Persistence.Setup
{
    public class DataSetup
    {
        public static IEnumerable<Currency> Currencies =>
            new Currency[]
            {
                new Currency
                {
                    Id = 1,
                    Code = Enum.GetName(typeof(SupportedCurrenciesCodes), SupportedCurrenciesCodes.USD_ARS)
                },
                new Currency
                {
                    Id = 2,
                    Code = Enum.GetName(typeof(SupportedCurrenciesCodes), SupportedCurrenciesCodes.BRL_ARS)
                },
                // TODO: Develop a CAD_ARSQuotationService implementing the BaseService and uncomment line below to enable the API to accept Canidian Dollars.
                /*
                new Currency
                 {
                    Id = Count++,
                    Code = Enum.GetName(typeof(SupportedCurrenciesCodes), SupportedCurrenciesCodes.CAD_ARS)
                },
                //*/
            };

    }
}
