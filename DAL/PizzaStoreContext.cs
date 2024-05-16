using BlazingPizzaDemoApp.Model;
using Humanizer;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizzaDemoApp.DAL;

public class PizzaStoreContext : DbContext
{
    public PizzaStoreContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<PizzaSpecial> Specials { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Pizza> Pizzas {get; set; }
    public DbSet<Topping> Toppings {get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Configuring a many-to-many special -> topping relationship that is friendly for serialization
        //configuring the relationships between your Pizza, Topping, and PizzaTopping entities in Entity Framework Core.


        //This line is configuring a composite key for the PizzaTopping entity using PizzaId and ToppingId.
        modelBuilder.Entity<PizzaTopping>().HasKey(pst => new { pst.PizzaId, pst.ToppingId });
        //This line is setting up a one-to - many relationship between Pizza and PizzaTopping.
        //It’s saying that one Pizza can have many PizzaToppings.
        modelBuilder.Entity<PizzaTopping>().HasOne<Pizza>().WithMany(ps => ps.Toppings);
        //This line is setting up a many-to -one relationship between PizzaTopping and Topping.
        //It’s saying that many PizzaToppings can be associated with one Topping.
        modelBuilder.Entity<PizzaTopping>().HasOne(ps => ps.Topping).WithMany();
    }
}
