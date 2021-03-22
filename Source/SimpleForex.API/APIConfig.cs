using Microsoft.Extensions.DependencyInjection;
using SimpleForex.API.Factories;
using SimpleForex.Application.Commands;
using SimpleForex.Application.Queries;
using SimpleForex.Application.Services;
using SimpleForex.Core.Collections;
using SimpleForex.Core.Contracts;
using SimpleForex.Core.Contracts.Factories;
using SimpleForex.Persistence.Services;

namespace SimpleForex.API
{
    public static class APIConfig
    {
        public static void ConfigIoCForCommands(this IServiceCollection services)
        {
            services.AddScoped<CreateCurrencyPurchaseCommand>();
        }

        public static void ConfigIoCForQueries(this IServiceCollection services)
        {
            services.AddScoped<GetCurrencyQuotationByCode>();
        }

        public static void ConfigIoCForServices(this IServiceCollection services)
        {
            services.AddScoped<ISupportedCurrencies, SupportedCurrencies>();
            services.AddScoped(typeof(QuotationWithURLService));
            services.AddScoped(typeof(BRL_ARSQuotationService));
        }

        public static void ConfigIoCForFactories(this IServiceCollection services)
        {
            services.AddScoped<ICommandFactory, CommandFactory>();
            services.AddScoped<IQueryFactory, QueryFactory>();
            services.AddScoped<IServiceFactory, ServiceFactory>();
            services.AddScoped<IRepositoryFactory, RepositoryFactory>();
        }

        public static void ConfigIoCServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(DataRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
