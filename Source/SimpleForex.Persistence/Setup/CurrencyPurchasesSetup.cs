using Microsoft.EntityFrameworkCore;
using SimpleForex.Core.Entities;

namespace SimpleForex.Persistence.Setup
{
    /// <summary>
    /// Represents all the addresses's entity configuration.
    /// To be use by the ORM entity framework.
    /// </summary>
    public static class CurrencyPurchasesSetup
    {
        /// <summary>
        /// Configures the client's ORM handler, following the business rules.
        /// </summary>
        /// <param name="modelBuilder">The ORM entity builder interface.</param>
        public static void ConfigureCurrencyPurchases(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyPurchase>()
                .HasKey(cp => cp.Id);

            modelBuilder.Entity<CurrencyPurchase>()
                .Property(cp => cp.Amount)
                .HasColumnType("money")
                .IsRequired();

            modelBuilder.Entity<CurrencyPurchase>()
                .Property(cp => cp.MadeOn)
                .IsRequired();

            modelBuilder.Entity<CurrencyPurchase>()
                .Property(cp => cp.UserId)
                .HasMaxLength(25)
                .IsRequired();

            modelBuilder.Entity<CurrencyPurchase>()
                .HasOne(cp => cp.Currency);
        }
    }
}
