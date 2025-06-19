using CodeBridgeGPT.DbContext.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeBridgeGPT.DbContext.DataLayer.DBContext
{
    public class DataLayerContext(DbContextOptions<DataLayerContext> options) : Microsoft.EntityFrameworkCore.DbContext(options)
    {
        public DbSet<Users> User { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional model configurations can be added here
        }
    }
}
