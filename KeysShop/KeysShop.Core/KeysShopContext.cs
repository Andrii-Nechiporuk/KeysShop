using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KeysShop.Core
{
    public class KeysShopContext : IdentityDbContext<User>
    {
        public KeysShopContext(DbContextOptions<KeysShopContext> options)
            : base(options)
        {
        }
    }
}