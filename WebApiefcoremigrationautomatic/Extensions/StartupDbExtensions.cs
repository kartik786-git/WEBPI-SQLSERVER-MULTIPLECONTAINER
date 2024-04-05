using EFCore.AutomaticMigrations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using WebApiefcoremigrationautomatic.Data;

namespace WebApiefcoremigrationautomatic.Extensions
{
    public static class StartupDbExtensions
    {
        public static async void CreateDbIfNotExists(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var blogContext = services.GetRequiredService<BLobDbContext>();

            var databsecrate = blogContext.Database.GetService<IDatabaseCreator>() 
                as RelationalDatabaseCreator;

            if (databsecrate != null)
            {
                if (!databsecrate.CanConnect()) databsecrate.Create();
                if (!databsecrate.HasTables()) databsecrate.CreateTables();
            }

            //blogContext.Database.EnsureCreated();

            // MigrateDatabaseToLatestVersion.Execute(blogContext);


            //MigrateDatabaseToLatestVersion.Execute(blogContext, 
            //   new DbMigrationsOptions { ResetDatabaseSchema = true,  });

            //blogContext.MigrateToLatestVersion();
            DBInitializerSeedData.InitializeDatabase(blogContext);
        }
    }
}
