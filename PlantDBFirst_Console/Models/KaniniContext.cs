using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace plantdbfirst_console.Models;

public partial class KaniniContext : DbContext
{
    public KaniniContext()
    {
    }

    public KaniniContext(DbContextOptions<KaniniContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Plant> Plants { get; set; }

  

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=MEGHANA;database=mvcefcore;integrated security=true;trustservercertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Plant>(entity =>
        {
            entity.HasKey(e => e.PlantId).HasName("PK__Plants__98FE395CF230E75C");

            entity.Property(e => e.PlantName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });
    }

      

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
