using HouseRental.Modules;
using Microsoft.EntityFrameworkCore;

namespace HouseRental.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // Define database tables
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Property table
            modelBuilder.Entity<Property>(entity =>
            {
                entity.Property(p => p.Price)
                      .HasColumnType("decimal(15,2)") // Configure MySQL decimal type
                      .IsRequired(); // Ensure the Price column is not nullable
            });
        }
    }
}