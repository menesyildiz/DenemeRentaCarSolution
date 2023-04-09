using Microsoft.EntityFrameworkCore;

namespace DenemeRentaCar.Entities
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Renter> Renters { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Gearbox> GearBoxes { get; set; }

        //public DatabaseContext()
        //{
        //    Database.EnsureCreated();
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB; database=DenemeRentaCarDb; trusted_connection=true");
        }
    }

    
}
