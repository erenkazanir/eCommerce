using eCommerce.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Order.Persistence.Context {
    public class OrderContext : DbContext {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Server=localhost,1440;initial Catalog=eCommerceOrderDb;User=sa;Password=123456aA;TrustServerCertificate=true");
            //optionsBuilder.UseSqlServer("Server=localhost,1440;initial Catalog=eCommerceOrderDb;User=sa;Password=123456aA;integrated Security=true;TrustServerCertificate=true");
        }


        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
    }
}