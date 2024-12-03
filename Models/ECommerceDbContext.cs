using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ECommerceWebApp.Models
{
    public class ECommerceDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }  // Ajout de la table des catégories
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId); // Configuration de la clé étrangère
        }
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
            : base(options)
        {
        }
    }
}
