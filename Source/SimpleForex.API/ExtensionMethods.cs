using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SimpleForex.Persistence.Setup;

namespace SimpleForex.Persistence
{
    public enum DBState
    {
        Fetched,
        Unfetched,
        Unmigrated
    }

    public static class ExtensionMethods
    {
        public static DBState IsDataFetched(this ApplicationDBContext context)
        {
            try
            {
                return (context.Currencies.Any()) ? DBState.Fetched : DBState.Unfetched;
            }
            catch (Exception ex)
            {
                Log.Error("Database data is not fetched.\nError: {0}.", ex.Message);
                return DBState.Unmigrated;
            }
        }

        public static void FetchDataBase(this ApplicationDBContext context)
        {
            if (IsDataFetched(context) == DBState.Unmigrated)
            {
                Log.Debug("Migrating database...");
                context.Database.Migrate();
                Log.Debug("Database migrated.");
            }

            if (!context.Currencies.Any())
            {
                Log.Debug("Currencies being populated...");
                context.Currencies.AddRange(DataSetup.Currencies);
                context.SaveChanges();
                Log.Debug("Currencies populated.");
            }
            else
            {
                Log.Debug("Currencies already populated.");
            }
        }
    }
}
