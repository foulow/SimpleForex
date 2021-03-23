using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using SimpleForex.Persistence;

namespace SimpleForex.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console(
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}",
                    theme: AnsiConsoleTheme.Literate)
                .WriteTo.File(
                    "api_errors.log",
                    Serilog.Events.LogEventLevel.Error,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            try
            {
                Log.Information("Building host...");
                var host = CreateHostBuilder(args).Build();
                Log.Information("Host builded.");

                if (args.Any(x => x.Contains("migrate")))
                    MigrateDataBase(host);

                Log.Information("Host runing...");
                host.Run();
            }
            catch (System.Exception ex)
            {
                Log.Fatal("--Host stopped: {0}  \n\n --InnerException: {1}",
                    ex.Message,
                    ex.InnerException);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseSerilog();
                });

        public static void MigrateDataBase(IHost host)
        {
            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var dbConfigContext = services.GetRequiredService<ApplicationDBContext>();

                Log.Information("Stating migration process...");
                if (!dbConfigContext.Database.EnsureCreated())
                {
                    dbConfigContext.Database.Migrate();
                }

                if (dbConfigContext.IsDataFetched() != DBState.Fetched)
                {
                    dbConfigContext.FetchDataBase();
                }
                Log.Information("Migration precess completed.");
            }
        }
    }
}
