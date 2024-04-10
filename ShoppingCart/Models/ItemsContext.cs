using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Models
{

    //public class ItemsContext : DbContext
    public class ItemsContext : IdentityDbContext<IdentityUser>
    {
        public ItemsContext(DbContextOptions<ItemsContext> options) :base(options)
        {
        }


        public DbSet<Item> products { get; set; }
    }
}
