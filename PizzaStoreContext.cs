using BlazingPizzaNavigation.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizzaNavigation;

public class PizzaStoreContext : DbContext
{
    public PizzaStoreContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<PizzaSpecial> Specials { get; set; }
}
