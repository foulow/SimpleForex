using Microsoft.Extensions.Configuration;

namespace SimpleForex.Core.Contracts
{
    public interface ISupportedCurrencies
    {
        IConfigurationSection Currencies { get; }

        void EnsuredSupported(string code);
        string GetCurrencyUrl(string code);
        decimal GetPurchaseLimit(string code);
        bool IsSupported(string code);
    }
}
