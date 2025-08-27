using CodeBridgePlatform.DbContext.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeBridgePlatform.DbContext.DataLayer.DBContext
{
    public class DataLayerContext(DbContextOptions<DataLayerContext> options) : Microsoft.EntityFrameworkCore.DbContext(options)
    {
        public DbSet<CodeBridgePlatformDbResponseModel> CodeBridgeGptDbResponse { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CodeBridgePlatformDbResponseModel>(entity =>
            {
                entity.HasKey(e => e.TaskResponseId);
            });
        }
    }
}
