using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PharmacyApp.Models
{
    public partial class PharmacyK209DBContext : DbContext
    {
        public PharmacyK209DBContext()
        {
        }

        public PharmacyK209DBContext(DbContextOptions<PharmacyK209DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Firm> Firms { get; set; }
        public virtual DbSet<MedToTag> MedToTags { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrdersItem> OrdersItems { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source =DESKTOP-HHG78VO\\MSSQLSERVER03;Initial Catalog = PharmacyK209DB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Firm>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<MedToTag>(entity =>
            {
                entity.ToTable("Med_to_Tags");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.MedToTags)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK__Med_to_Ta__Medic__2B3F6F97");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.MedToTags)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("FK__Med_to_Ta__TagId__2C3393D0");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.ToTable("Medicine");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.ExpireDate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductionDate).HasColumnType("date");

                entity.HasOne(d => d.Firm)
                    .WithMany(p => p.Medicines)
                    .HasForeignKey(d => d.FirmId)
                    .HasConstraintName("FK__Medicine__FirmId__267ABA7A");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.PurchaseDate).HasColumnType("date");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.WorkerId)
                    .HasConstraintName("FK__Orders__WorkerId__30F848ED");
            });

            modelBuilder.Entity<OrdersItem>(entity =>
            {
                entity.Property(e => e.ItemPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.OrdersItems)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK__OrdersIte__Medic__33D4B598");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrdersItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrdersIte__Order__34C8D9D1");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.Property(e => e.Fullname).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(500);

                entity.Property(e => e.Username).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
