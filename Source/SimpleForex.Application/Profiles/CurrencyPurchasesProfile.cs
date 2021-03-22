using AutoMapper;
using SimpleForex.Application.DTOs;
using SimpleForex.Core.Entities;

namespace SimpleForex.Application.Profiles
{
    /// <summary>
    /// CurrenyPurchases mapping configurations.
    /// </summary>
    public class CurrencyPurchasesProfile : Profile
    {
        /// <summary>
        /// Maps a CurrencyPurchase to a CurrencyPurchaseDTO.
        /// </summary>
        public CurrencyPurchasesProfile()
        {
            CreateMap<CurrencyPurchase, CurrencyPurchaseDTO>();
        }
    }

    /// <summary>
    /// CurrenyPurchases mapping configurations.
    /// </summary>
    public class CurrencyPurchaseCreateProfile : Profile
    {
        /// <summary>
        /// Maps a CurrencyPurchaseCreateDTO to a CurrencyPurchase.
        /// </summary>
        public CurrencyPurchaseCreateProfile()
        {
            CreateMap<CurrencyPurchaseCreateDTO, CurrencyPurchase>()
                .ForMember(cp => cp.Id, action => action.Ignore())
                .ForMember(cp => cp.MadeOn, action => action.Ignore());
        }
    }
}
