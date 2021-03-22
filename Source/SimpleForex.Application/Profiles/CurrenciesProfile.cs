using AutoMapper;
using SimpleForex.Application.DTOs;
using SimpleForex.Core.Entities;

namespace SimpleForex.Application.Profiles
{
    /// <summary>
    /// Currenies mapping configuration.
    /// </summary>
    public class CurrenciesProfile : Profile
    {
        public CurrenciesProfile()
        {
            CreateMap<CurrencyDTO, Currency>()
                .ForMember(client => client.Id, action => action.Ignore());

            CreateMap<Currency, CurrencyDTO>();
        }
    }
}
