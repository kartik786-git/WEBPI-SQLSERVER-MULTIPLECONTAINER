using Microsoft.EntityFrameworkCore;
using WebApiefcoremigrationautomatic.Entity;

namespace WebApiefcoremigrationautomatic.Data
{
    public class BLobDbContext : DbContext
    {
        public BLobDbContext(DbContextOptions<BLobDbContext> dbContextOptions):
            base(dbContextOptions)
        {
            
        }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Dmeo> Demos { get; set; }
    }
}
