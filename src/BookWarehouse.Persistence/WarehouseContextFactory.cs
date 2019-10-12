using System;
using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BookWarehouse.Persistence
{
    public class WarehouseContextFactory : IDesignTimeDbContextFactory<WarehouseContext>
    {
        public WarehouseContext CreateDbContext(string[] args)
        {
            var runtimePath = GetRuntimePath();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(runtimePath)
                .AddJsonFile("appsettings.json")
                .Build();

            return new WarehouseContext(CreateOptions(configuration));
        }

        private static string GetRuntimePath()
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var assemblyFile = executingAssembly.Location;

            return Path.GetDirectoryName(assemblyFile);
        }

        public static DbContextOptions<WarehouseContext> CreateOptions(IConfiguration configuration)
        {
            if (configuration == null) 
                throw new ArgumentNullException(nameof(configuration));

            var contextOptions = new DbContextOptionsBuilder<WarehouseContext>();
            
            contextOptions.UseSqlServer(configuration["Database:ConnectionString"]);

            return contextOptions.Options;
        }
    }
}