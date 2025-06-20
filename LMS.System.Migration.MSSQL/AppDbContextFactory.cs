using LMS.System.Domain.Services.DBServices.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LMS.System.Migrations.MSSQL
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationContext>()
                .UseSqlServer("Server=winserv22-2;Database=DB1;Integrated Security=True;Connect Timeout=480;TrustServerCertificate=True",
                b => b.MigrationsAssembly(typeof(AppDbContextFactory).Assembly.FullName));

            return new ApplicationContext(optionBuilder.Options);
        }
    }
}
