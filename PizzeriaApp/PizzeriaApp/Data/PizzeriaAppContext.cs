using Microsoft.EntityFrameworkCore;
using PizzeriaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaApp.Data
{
    public class PizzeriaAppContext : DbContext
    {
        public PizzeriaAppContext(DbContextOptions<PizzeriaAppContext> options) : base (options)
        {

        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PizzaIngredient>().HasKey(pi => new { pi.PizzaId, pi.IngredientId });

            modelBuilder.Entity<PizzaIngredient>()
                .HasOne(pi => pi.Pizza)
                .WithMany(pi => pi.PizzaIngredients)
                .HasForeignKey(p => p.IngredientId);

            modelBuilder.Entity<PizzaIngredient>()
                .HasOne(pi => pi.Ingredient)
                .WithMany(pi => pi.PizzaIngredients)
                .HasForeignKey(p => p.PizzaId);
        }
    }
}
