using Microsoft.EntityFrameworkCore;

namespace Kart.Models
{
    public class KartDbContext:DbContext
    {
        public KartDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
