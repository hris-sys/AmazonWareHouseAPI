using Data.Models.Interfaces;
using Data.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Data.Connection
{
    public class AmazonDbContext : DbContext
    {
        public AmazonDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemCategory> ItemsCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrdersItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=AmazonWareHouseDb;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyEntityChanges();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        private void ApplyEntityChanges()
        {
            var entries = this.ChangeTracker.Entries().Where(x => x.Entity is IAuditInfo && x.State == EntityState.Added || x.State == EntityState.Deleted || x.State == EntityState.Modified).ToList();

            foreach (var entry in entries)
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.Now;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    entity.DeletedAt = DateTime.Now;
                }
                else
                {
                    entity.ModifiedAt = DateTime.Now;
                }
            }
        }
    }
}
