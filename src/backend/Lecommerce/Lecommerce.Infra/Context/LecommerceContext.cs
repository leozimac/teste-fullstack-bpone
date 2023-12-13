using Lecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lecommerce.Infra.Context
{
    public class LecommerceContext : DbContext
    {
        public LecommerceContext(DbContextOptions<LecommerceContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> Items { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
