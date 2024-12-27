using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;

namespace VtOdev.Models;

public partial class DbodevContext : DbContext
{
    public DbodevContext()
    {
    }

    public DbodevContext(DbContextOptions<DbodevContext> options)
        : base(options)
    {
    }
    public DbSet<dbLog> DbLogs { get; set; }
    public virtual DbSet<EfmigrationsLock> EfmigrationsLocks { get; set; }

    public virtual DbSet<Musteri> Musteris { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Sipari> Siparis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)=> optionsBuilder.UseSqlite("Data Source=.\\\\\\\\Data\\\\\\\\dbodev.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EfmigrationsLock>(entity =>
        {
            entity.ToTable("__EFMigrationsLock");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Musteri>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasIndex(e => e.Id, "IX_Musteri_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.HasIndex(e => e.Id, "IX_Product_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<Sipari>(entity =>
        {
            entity.HasIndex(e => e.Id, "IX_Siparis_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MusteriId).HasColumnName("musteriId");
            entity.Property(e => e.ProductId).HasColumnName("productId");

            entity.HasOne(d => d.Product).WithMany(p => p.Siparis)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            entity.HasOne(d => d.Musteri).WithMany(p => p.Siparis)
                .HasForeignKey(d => d.MusteriId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
