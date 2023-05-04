using Microsoft.EntityFrameworkCore;
using PruebaSTJuanTrejo.Entities;

namespace PruebaSTJuanTrejo.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<ItemToCustomer> ItemToCustomers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Item>().ToTable("Items");
            modelBuilder.Entity<Store>().ToTable("Stores");
            modelBuilder.Entity<ItemToCustomer>().ToTable("ItemToCustomers");

            //SEED DATA
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Administrador",
                LastName = "Administrador",
                Address = "Dirección de prueba",
                EmailAddress ="admin@gmail.com",
                Password = "123456789"
            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = Guid.NewGuid(),
                Code = "ABC1234567",
                Description = "Producto de prueba",
                Image = "----",
                Price = 1000.21,
                Stock = 100
            });

            modelBuilder.Entity<Store>().HasData(new Store
            {
                Id = Guid.NewGuid(),
                Address = "Dirección de prueba",
                Branch = "Rama A",
            });
        }

        public DataContext(DbContextOptions<DataContext> dbcontext):base(dbcontext)
        {

        }

    }
}
