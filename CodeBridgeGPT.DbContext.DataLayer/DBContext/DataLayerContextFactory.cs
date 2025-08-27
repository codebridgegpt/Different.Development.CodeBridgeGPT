using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CodeBridgePlatform.DbContext.DataLayer.DBContext
{
    public class DataLayerContextFactory : IDesignTimeDbContextFactory<DataLayerContext>
    {
        public DataLayerContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory();

            var configuration = new ConfigurationBuilder().SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<DataLayerContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new DataLayerContext(optionsBuilder.Options);
        }
    }
}