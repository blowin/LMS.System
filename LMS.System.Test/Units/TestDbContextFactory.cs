using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace LMS.System.Test.Units
{
    public class TestDbContextFactory
    {
        public static TContext Create<TContext>()
            where TContext : DbContext
        {
#pragma warning disable CA2000
            var sqliteConnection = new SqliteConnection("Data Source=:memory:");
#pragma warning restore CA2000
            sqliteConnection.Open();

            var options = new DbContextOptionsBuilder<TContext>()
                .EnableDetailedErrors()
                .UseSqlite(sqliteConnection, contextOwnsConnection: false)
                .Options;

            var db = (TContext?)Activator.CreateInstance(typeof(TContext), options)
                ?? throw new InvalidOperationException($"Unable to create: '{typeof(TContext).Name}'");

            db.Database.EnsureCreated();
            return db;
        }
    }
}
