using Microsoft.EntityFrameworkCore;

namespace ContactApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
    }
}
