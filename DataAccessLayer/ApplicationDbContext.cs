using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Sidekick.NET.Constant;
using static Sidekick.NET.Types;

namespace DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetCategory(modelBuilder);
            SetProduct(modelBuilder);
            SetUserTable(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void SetCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasKey(c => c.ID);

            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .HasMaxLength(20)
                .IsUnicode()
                .IsRequired();

            modelBuilder.Entity<Category>()
                .Property(c => c.CreationDate)
                .HasColumnType("date")
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Category>()
                .Property(c => c.Status)
                .HasColumnType("tinyint")
                .HasDefaultValue(CategoryStatus.ACTIVE)
                .IsRequired();
        }

        private static void SetProduct(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(p => p.ID);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Grantor)
                .WithMany(u => u.Products)
                .HasForeignKey(p => p.GrantorID);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryID);

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.Address)
                .HasMaxLength(200)
                .IsUnicode();

            modelBuilder.Entity<Product>()
                .Property(p => p.Details)
                .HasMaxLength(500)
                .IsUnicode();

            modelBuilder.Entity<Product>()
                .Property(p => p.CreationDate)
                .HasColumnType("date")
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Product>()
                .Property(p => p.PublishDate)
                .HasColumnType("date")
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Product>()
                .Property(p => p.Status)
                .HasColumnType("tinyint")
                .HasDefaultValue(ProductStatus.ACTIVE)
                .IsRequired();
        }
        
        private static void SetUserTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.ID);

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Mail)
                .HasMaxLength(507)
                .IsUnicode();

            modelBuilder.Entity<User>()
                .Property(u => u.Address)
                .HasMaxLength(200)
                .IsUnicode();

            modelBuilder.Entity<User>()
                .Property(u => u.ProfilePhotoLink)
                .HasMaxLength(1000)
                .IsUnicode();

            modelBuilder.Entity<User>()
                .Property(u => u.CreationDate)
                .HasColumnType("date")
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<User>()
                .Property(u => u.LastSeen)
                .HasColumnType("smalldatetime")
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<User>()
                .Property(u => u.Status)
                .HasColumnType("tinyint")
                .HasDefaultValue(UserStatus.ACTIVE)
                .IsRequired();
        }

        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
