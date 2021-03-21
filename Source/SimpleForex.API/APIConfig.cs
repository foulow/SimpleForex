using Microsoft.Extensions.DependencyInjection;
using SimpleForex.API.Factories;
using SimpleForex.Application.Commands;
using SimpleForex.Application.Queries;
using SimpleForex.Core.Contracts;
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
            services.AddScoped<GetCurrencyByCode>();
            services.AddScoped<GetCurrencyPurchasesQuery>();
        }

        public static void ConfigIoCForFactories(this IServiceCollection services)
        {
            services.AddScoped<ICommandFactory, CommandFactory>();
            services.AddScoped<IQueryFactory, QueryFactory>();
            services.AddScoped<IRepositoryFactory, RepositoryFactory>();
        }

        public static void ConfigIoCServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(DataRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
