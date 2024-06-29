using MagicVilla_VillaAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
        public DbSet<Villa>villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<RefreshToken>RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Villa>().HasData(
                new Villa { Id = 1, Name = "Villa Sunshine", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Details = "Beautiful villa with sea view.", Sqft = 2500, Occupancy = 8, ImageLocalPath = "https://example.com/villa1.jpg", Amenity = "Pool, Wi-Fi, BBQ", Rate = 350.00 },
                new Villa { Id = 2, Name = "Mountain Retreat", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Details = "Cozy retreat in the mountains.", Sqft = 1500, Occupancy = 6, ImageLocalPath = "https://example.com/villa2.jpg", Amenity = "Fireplace, Hot Tub", Rate = 200.00 },
                new Villa { Id = 3, Name = "Urban Oasis", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Details = "Modern villa in the city center.", Sqft = 1800, Occupancy = 4, ImageLocalPath = "https://example.com/villa3.jpg", Amenity = "Gym, Wi-Fi", Rate = 300.00 },
                new Villa { Id = 4, Name = "Beachfront Paradise", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Details = "Luxury villa right on the beach.", Sqft = 3000, Occupancy = 10, ImageLocalPath = "https://example.com/villa4.jpg", Amenity = "Pool, Private Beach", Rate = 500.00 },
                new Villa { Id = 5, Name = "Countryside Escape", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Details = "Charming villa in the countryside.", Sqft = 2200, Occupancy = 5, ImageLocalPath = "https://example.com/villa5.jpg", Amenity = "Garden, Wi-Fi", Rate = 250.00 },
                new Villa { Id = 6, Name = "Desert Hideaway", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Details = "Quiet villa in the desert.", Sqft = 1600, Occupancy = 4, ImageLocalPath = "https://example.com/villa6.jpg", Amenity = "Pool, Outdoor Shower", Rate = 280.00 },
                new Villa { Id = 7, Name = "Lakeside Cottage", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Details = "Relaxing villa by the lake.", Sqft = 2000, Occupancy = 6, ImageLocalPath = "https://example.com/villa7.jpg", Amenity = "Canoe, Fireplace", Rate = 220.00 },
                new Villa { Id = 8, Name = "Tropical Getaway", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Details = "Exotic villa in a tropical setting.", Sqft = 2700, Occupancy = 8, ImageLocalPath = "https://example.com/villa8.jpg", Amenity = "Pool, Hammocks", Rate = 400.00 },
                new Villa { Id = 9, Name = "Ski Chalet", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Details = "Comfortable villa near the ski slopes.", Sqft = 1400, Occupancy = 5, ImageLocalPath = "https://example.com/villa9.jpg", Amenity = "Ski Storage, Hot Tub", Rate = 310.00 },
                new Villa { Id = 10, Name = "Forest Retreat", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Details = "Peaceful villa in the forest.", Sqft = 1900, Occupancy = 6, ImageLocalPath = "https://example.com/villa10.jpg", Amenity = "Hiking Trails, Wi-Fi", Rate = 270.00 }
            );
        }
    }

}
