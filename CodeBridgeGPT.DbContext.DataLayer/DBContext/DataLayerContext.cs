using CodeBridgePlatform.DbContext.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeBridgePlatform.DbContext.DataLayer.DBContext
{
    public class DataLayerContext(DbContextOptions<DataLayerContext> options) : Microsoft.EntityFrameworkCore.DbContext(options)
    {
        public DbSet<CodeBridgeGptResponseModel> CodeBridgeGptDbResponse { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CodeBridgeGptResponseModel>(entity =>
            {
                entity.HasKey(e => e.TaskResponseId);
            });
        }
    }
}
