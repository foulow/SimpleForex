using AutoMapper;
using SimpleForex.Application.DTOs;
using SimpleForex.Core.Entities;

namespace SimpleForex.Application.Profiles
{
    /// <summary>
    /// CurrenyPurchases mapping configuration.
    /// </summary>
    public class CurrencyPurchasesProfile : Profile
    {
        public CurrencyPurchasesProfile()
        {
            CreateMap<CurrencyPurchaseDTO, CurrencyPurchase>()
                .ForMember(address => address.Id, action => action.Ignore());

            CreateMap<CurrencyPurchase, CurrencyPurchaseDTO>();
        }
    }
}
