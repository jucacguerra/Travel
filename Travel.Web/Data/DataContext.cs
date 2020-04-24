using Microsoft.EntityFrameworkCore;
using Travel.Web.Data.Entities;

namespace Travel.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<CountryEntity> Countrys { get; set; }

        public DbSet<CityEntity> Citys { get; set; }

        public DbSet<TripEntity> Trips { get; set; }

        public DbSet<TripDetailEntity> TripDetails { get; set; }

        public DbSet<EmployeeEntity> Employees { get; set; }

        public DbSet<ExpenseTypeEntity> ExpenseTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CountryEntity>()
                .HasIndex(c => c.Name)
                .IsUnique();

        }

    }
}
