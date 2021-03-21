using Microsoft.EntityFrameworkCore;
using SimpleForex.Core.Entities;

namespace SimpleForex.Persistence.Setup
{
    /// <summary>
    /// Represents all the client's entity configuration.
    /// To be use by the ORM entity framework.
    /// </summary>
    public static class CurrenciesSetup
    {
        /// <summary>
        /// Configures the client's ORM handler, following the business rules.
        /// </summary>
        /// <param name="modelBuilder">The ORM entity builder interface.</param>
        public static void ConfigureCurrencies(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Currency>()
                .Property(c => c.Code)
                .HasMaxLength(7)
                .IsRequired();
        }
    }
}
