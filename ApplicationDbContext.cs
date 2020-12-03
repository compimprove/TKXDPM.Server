using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using TKXDPM_API.Model;

namespace TKXDPM_API
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BikeInStation>()
                .HasKey(key => new {key.BikeId, key.StationId});
            
            modelBuilder.Entity<Address>().HasData(Address.GetSeederData());
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<BikeInStation> BikeInStation { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}