using Microsoft.EntityFrameworkCore;
using StoreMVC.Models.Domain;

namespace StoreMVC.Services.DatabaseContext
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }

    }
}
