using System;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using SimpleForex.API.Validations;
using SimpleForex.Application.Profiles;
using SimpleForex.Persistence;

namespace SimpleForex.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
#if MOCK
            services.AddDbContext<ApplicationDBContext>(options => options
                .UseLazyLoadingProxies()
                .UseSqlite("Data Source=sqlite.db"));
            // If you want to do a quick test.
            // services.AddDbContext<ApplicationDBContext>(options =>
            //                 options.UseInMemoryDatabase("applicationDb"));
#else
            var migrationsAssembly = typeof(Startup).Assembly.GetName().FullName;
            services.AddDbContext<ApplicationDBContext>(options =>
                            options.UseSqlServer(Configuration.GetConnectionString(name: "DefaultConnection"),
                                sql => sql.MigrationsAssembly(migrationsAssembly))
                                .UseLazyLoadingProxies());
#endif

            services.AddControllers(
                options =>
                {
                    options.Filters.Add<ValidationResultAttribute>();
                })
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CurrencyPurchaseDTOValidation>());

            services.AddHttpContextAccessor();

            services.AddAutoMapper(typeof(CurrenciesProfile).Assembly);

            services.AddTransient<IValidatorInterceptor, DtoValidatorInterceptor>();

            services.ConfigIoCServices();
            services.ConfigIoCForFactories();
            services.ConfigIoCForServices();
            services.ConfigIoCForCommands();
            services.ConfigIoCForQueries();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SimpleForex.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "*/*";

                    var exceptionHandlerPathFeature =
                        context.Features.Get<IExceptionHandlerPathFeature>();

                    if (exceptionHandlerPathFeature?.Error is Exception ex)
                    {
                        await Task.Run(() =>
                        {
                            Log.Fatal("Server-side Error: {0}", ex.Message);
                        });
                    }
                });
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "SimpleForex.API");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
