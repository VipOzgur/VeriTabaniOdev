﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VtOdev.Models;

#nullable disable

namespace VtOdev.Migrations
{
    [DbContext(typeof(DbodevContext))]
    partial class DbodevContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("VtOdev.Models.EfmigrationsLock", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Timestamp")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("__EFMigrationsLock", (string)null);
                });

            modelBuilder.Entity("VtOdev.Models.Musteri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedAt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "IX_Musteri_id")
                        .IsUnique();

                    b.ToTable("Musteris");
                });

            modelBuilder.Entity("VtOdev.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Fiyat")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Stok")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UpdatedAt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "IX_Product_id")
                        .IsUnique();

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("VtOdev.Models.Sipari", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("Adet")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MusteriId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("musteriId");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("productId");

                    b.Property<string>("Tarih")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedAt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MusteriId");

                    b.HasIndex("ProductId");

                    b.HasIndex(new[] { "Id" }, "IX_Siparis_id")
                        .IsUnique();

                    b.ToTable("Siparis");
                });

            modelBuilder.Entity("VtOdev.Models.dbLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedAt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DbLogs");
                });

            modelBuilder.Entity("VtOdev.Models.Sipari", b =>
                {
                    b.HasOne("VtOdev.Models.Musteri", "Musteri")
                        .WithMany("Siparis")
                        .HasForeignKey("MusteriId")
                        .IsRequired();

                    b.HasOne("VtOdev.Models.Product", "Product")
                        .WithMany("Siparis")
                        .HasForeignKey("ProductId")
                        .IsRequired();

                    b.Navigation("Musteri");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("VtOdev.Models.Musteri", b =>
                {
                    b.Navigation("Siparis");
                });

            modelBuilder.Entity("VtOdev.Models.Product", b =>
                {
                    b.Navigation("Siparis");
                });
#pragma warning restore 612, 618
        }
    }
}
