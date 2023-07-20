using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElC.Classes
{
    public class InventoryEntity : DbContext
    {

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<customer> Customer { get; set; }
        public DbSet<supplier> Supplier { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Cashier> Cashier { get; set; }
        public DbSet<OrderSupplier> OrderSupplier { get; set; }
        public DbSet<OrderItemSupplier> OrderItemSupplier { get; set; }
        public DbSet<ReturnCustomerProduct> ReturnCustomerProduct { get; set; }
        public DbSet<ReturnInventoryProduct> ReturnInventoryProduct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog = InventorySystem ;Integrated Security = True;  Encrypt = False");
        }


    }
}
