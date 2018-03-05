namespace RentalCars.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using RentalCars.Data.Models;

    public class RentalCarsDbContext : IdentityDbContext<User>
    {
        public RentalCarsDbContext(DbContextOptions<RentalCarsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Agency> Agencies { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<RentalOrder> RentalOrders { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Agency>()
                .HasIndex(a => a.Name)
                .IsUnique(true);

            builder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(fk => fk.UserId);

            builder.Entity<Car>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Car)
                .HasForeignKey(fk => fk.CarId);

            builder.Entity<Agency>()
                .HasMany(a => a.Cars)
                .WithOne(c => c.Agency)
                .HasForeignKey(fk => fk.AgencyId);

            builder.Entity<AgencyCity>()
                .HasKey(sa => new { sa.AgencyId, sa.CityId });

            builder.Entity<AgencyCity>()
                .HasOne(sa => sa.City)
                .WithMany(c => c.Agencies)
                .HasForeignKey(fk => fk.CityId);

            builder.Entity<AgencyCity>()
                .HasOne(sa => sa.Agency)
                .WithMany(c => c.Cities)
                .HasForeignKey(fk => fk.AgencyId);

            builder.Entity<User>()
                .HasOne(u => u.Agency)
                .WithOne(a => a.User)
                .HasForeignKey<Agency>(fk => fk.UserId);

            builder.Entity<Car>()
                .HasOne(c => c.City)
                .WithMany(ci => ci.Cars)
                .HasForeignKey(fk => fk.CityId);

            builder.Entity<Agency>()
            .HasOne(a => a.Image)
            .WithOne(i => i.Agency)
            .HasForeignKey<Image>(b => b.AgencyId);

            base.OnModelCreating(builder);
        }
    }
}
