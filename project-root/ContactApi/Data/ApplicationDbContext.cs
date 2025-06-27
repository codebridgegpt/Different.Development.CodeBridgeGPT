using Microsoft.EntityFrameworkCore;
using ContactApi.Models;

namespace ContactApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}