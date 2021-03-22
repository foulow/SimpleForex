using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleForex.Core.Entities;
using SimpleForex.Persistence.Setup;

namespace SimpleForex.Persistence
{
    /// <summary>
    /// Represents the application database context, 
    /// allowing the communication between the application and the database.
    /// </summary>
    public class ApplicationDBContext : DbContext
    {
        /// <summary>
        /// Default constructor needed for netcore-ef migration tools.
        /// </summary>
        public ApplicationDBContext() { }

        /// <summary>
        /// Default constructor use with DI in the startup file.
        /// </summary>
        /// <param name="options">The options to be use by the DbContext.</param>
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }


        /// <summary>
        /// ORM access to the data base table Clients.
        /// </summary>
        public virtual DbSet<Currency> Currencies { get; set; }

        /// <summary>
        /// ORM access to the data base table Addresses.
        /// </summary>
        public virtual DbSet<CurrencyPurchase> CurrencyPurchases { get; set; }
        public IConfiguration Configuration { get; }


        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;

            var migrationsAssembly = typeof(ApplicationDBContext).Assembly.GetName().FullName;

            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Default"),
                    sql => sql.MigrationsAssembly(migrationsAssembly))
                    .UseLazyLoadingProxies();
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureCurrencies();

            modelBuilder.ConfigureCurrencyPurchases();

            base.OnModelCreating(modelBuilder);
        }
    }
}
