using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace KeysShop.Core
{
    public class KeysShopContext : IdentityDbContext<User>
    {
        public KeysShopContext(DbContextOptions<KeysShopContext> options)
            : base(options)
        {
        }

        public DbSet<Key> Keys { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Bucket> Buckets { get; set; }
    }
}