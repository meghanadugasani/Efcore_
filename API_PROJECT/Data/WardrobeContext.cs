using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using WardrobeAPI.Models;

namespace WardrobeAPI.Data
{
    public class WardrobeContext : DbContext
    {
        public WardrobeContext(DbContextOptions<WardrobeContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Wardrobe> Wardrobes { get; set; }
        public DbSet<Dress> Dresses { get; set; }
        public DbSet<Outfit> Outfits { get; set; }
        public DbSet<OutfitDress> OutfitDresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User-Wardrobe (1-M)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Wardrobes)
                .WithOne(w => w.User)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Wardrobe-Dress (1-M)
            modelBuilder.Entity<Wardrobe>()
                .HasMany(w => w.Dresses)
                .WithOne(d => d.Wardrobe)
                .HasForeignKey(d => d.WardrobeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Outfit-Dress (many-to-many via OutfitDress)
            modelBuilder.Entity<OutfitDress>()
                .HasKey(od => new { od.OutfitId, od.DressId });

            modelBuilder.Entity<OutfitDress>()
                .HasOne(od => od.Outfit)
                .WithMany(o => o.OutfitDresses)
                .HasForeignKey(od => od.OutfitId);

            modelBuilder.Entity<OutfitDress>()
                .HasOne(od => od.Dress)
                .WithMany(d => d.OutfitDresses)
                .HasForeignKey(od => od.DressId);
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Name = "Alice", Email = "alice@example.com", Password = "pass123", Role = "Admin" },
                new User { UserId = 2, Name = "Bob", Email = "bob@example.com", Password = "pass456", Role = "User" }
            );

            modelBuilder.Entity<Wardrobe>().HasData(
                new Wardrobe { WardrobeId = 1, Name = "Alice's Wardrobe", UserId = 1 },
                new Wardrobe { WardrobeId = 2, Name = "Bob's Wardrobe", UserId = 2 }
            );

            modelBuilder.Entity<Dress>().HasData(
                new Dress { DressId = 1, Name = "Red Dress", Color = "Red", Size = "M", Season = "Summer", Style = "Casual", WardrobeId = 1 },
                new Dress { DressId = 2, Name = "Blue Dress", Color = "Blue", Size = "L", Season = "Winter", Style = "Formal", WardrobeId = 2 }
            );

            modelBuilder.Entity<Outfit>().HasData(
                new Outfit { OutfitId = 1, Name = "Summer Party", Occasion = "Party", Season = "Summer", Style = "Casual" }
            );

            modelBuilder.Entity<OutfitDress>().HasData(
                new OutfitDress { OutfitId = 1, DressId = 1 } 
            );
        }
    }
}
