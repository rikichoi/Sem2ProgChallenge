using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ChallengeAPI.Models
{
    public partial class challengeContext : DbContext
    {
        public challengeContext()
        {
        }

        public challengeContext(DbContextOptions<challengeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;
        public virtual DbSet<Segment> Segments { get; set; } = null!;
        public virtual DbSet<Shipping> Shippings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("PK__Category__6A1C8ADA8AE58D8C");

                entity.ToTable("Category");

                entity.Property(e => e.CatId)
                    .ValueGeneratedNever()
                    .HasColumnName("CatID");

                entity.Property(e => e.CatName).HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustId)
                    .HasName("PK__Customer__049E3A89C57A6A68");

                entity.ToTable("Customer");

                entity.Property(e => e.CustId)
                    .HasMaxLength(50)
                    .HasColumnName("CustID");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Region).HasMaxLength(50);

                entity.Property(e => e.SegId).HasColumnName("SegID");

                entity.Property(e => e.State).HasMaxLength(50);

                entity.HasOne(d => d.RegionNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.Region)
                    .HasConstraintName("FK__Customer__Region__40F9A68C");

                entity.HasOne(d => d.Seg)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.SegId)
                    .HasConstraintName("FK__Customer__SegID__40058253");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => new { e.OrderDate, e.CustId, e.ProdId })
                    .HasName("PK__Order__32CDC667494CE5CA");

                entity.ToTable("Order");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.CustId)
                    .HasMaxLength(50)
                    .HasColumnName("CustID");

                entity.Property(e => e.ProdId)
                    .HasMaxLength(50)
                    .HasColumnName("ProdID");

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.Property(e => e.ShipDate).HasColumnType("date");

                entity.Property(e => e.ShipMode).HasMaxLength(50);

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__CustID__44CA3770");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__ProdID__43D61337");

                entity.HasOne(d => d.ShipModeNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShipMode)
                    .HasConstraintName("FK__Order__ShipMode__45BE5BA9");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProdId)
                    .HasName("PK__Product__042785C5A4C110DC");

                entity.ToTable("Product");

                entity.Property(e => e.ProdId)
                    .HasMaxLength(50)
                    .HasColumnName("ProdID");

                entity.Property(e => e.CatId).HasColumnName("CatID");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK__Product__CatID__3D2915A8");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.Region1)
                    .HasName("PK__Region__D3C7740666ECDF45");

                entity.ToTable("Region");

                entity.Property(e => e.Region1)
                    .HasMaxLength(50)
                    .HasColumnName("Region");
            });

            modelBuilder.Entity<Segment>(entity =>
            {
                entity.HasKey(e => e.SegId)
                    .HasName("PK__Segment__175AE85EAA114C9A");

                entity.ToTable("Segment");

                entity.Property(e => e.SegId)
                    .ValueGeneratedNever()
                    .HasColumnName("SegID");

                entity.Property(e => e.SegName).HasMaxLength(50);
            });

            modelBuilder.Entity<Shipping>(entity =>
            {
                entity.HasKey(e => e.ShipMode)
                    .HasName("PK__Shipping__D09F41FB521E5A4C");

                entity.ToTable("Shipping");

                entity.Property(e => e.ShipMode).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
