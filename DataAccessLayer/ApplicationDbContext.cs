using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Sidekick.NET.Constant.SQL;
using Sidekick.NET.Constant.Validation;
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
                .HasMaxLength(Rule.Category.Name.MAX_LENGTH)
                .IsUnicode()
                .IsRequired();

            modelBuilder.Entity<Category>()
                .Property(c => c.DateCreated)
                .HasColumnType(Rule.Category.DateCreated.DATA_TYPE)
                .HasDefaultValueSql(Rule.Category.DateCreated.DEFAULT_VALUE_SQL);

            modelBuilder.Entity<Category>()
               .Property(c => c.DateModified)
               .HasColumnType(Rule.Category.DateModified.DATA_TYPE)
               .HasDefaultValueSql(Rule.Category.DateModified.DEFAULT_VALUE_SQL);

            modelBuilder.Entity<Category>()
                .Property(c => c.Status)
                .HasColumnType(Rule.Category.Status.DATA_TYPE)
                .HasDefaultValue(Rule.Category.Status.DEFAULT_VALUE)
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
                .HasMaxLength(Rule.Product.Name.MAX_LENGTH)
                .IsUnicode()
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.Details)
                .HasMaxLength(Rule.Product.Details.MAX_LENGTH)
                .IsUnicode();

            modelBuilder.Entity<Product>()
                .Property(p => p.Address)
                .HasMaxLength(Rule.Product.Address.MAX_LENGTH)
                .IsUnicode();

            modelBuilder.Entity<Product>()
                .Property(p => p.PhotoURL)
                .HasMaxLength(Rule.Product.PhotoURL.MAX_LENGTH)
                .IsUnicode();

            modelBuilder.Entity<Product>()
                .Property(p => p.DatePublished)
                .HasColumnType(Rule.Product.DatePublished.DATA_TYPE)
                .HasDefaultValueSql(Rule.Product.DatePublished.DEFAULT_VALUE_SQL);

            modelBuilder.Entity<Product>()
              .Property(u => u.DateCreated)
              .HasColumnType(Rule.User.DateCreated.DATA_TYPE)
              .HasDefaultValueSql(Rule.User.DateCreated.DEFAULT_VALUE_SQL);

            modelBuilder.Entity<Product>()
               .Property(u => u.DateModified)
               .HasColumnType(Rule.User.DateModified.DATA_TYPE)
               .HasDefaultValueSql(Rule.User.DateModified.DEFAULT_VALUE_SQL);

            modelBuilder.Entity<Product>()
                .Property(p => p.Status)
                .HasColumnType(Rule.Product.Status.DATA_TYPE)
                .HasDefaultValue(Rule.Product.Status.DEFAULT_VALUE)
                .IsRequired();
        }

        private static void SetUserTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.ID);

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .HasMaxLength(Rule.User.Name.MAX_LENGTH)
                .IsUnicode()
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasMaxLength(Rule.User.Email.MAX_LENGTH)
                .IsUnicode();

            modelBuilder.Entity<User>()
                .Property(u => u.Address)
                .HasMaxLength(Rule.User.Address.MAX_LENGTH)
                .IsUnicode();

            modelBuilder.Entity<User>()
                .Property(u => u.ProfilePhotoURL)
                .HasMaxLength(Rule.User.ProfilePhotoURL.MAX_LENGTH)
                .IsUnicode();

            modelBuilder.Entity<User>()
                .Property(u => u.LastSeen)
                .HasColumnType(Rule.User.LastSeen.DATA_TYPE)
                .HasDefaultValueSql(Rule.User.LastSeen.DEFAULT_VALUE_SQL);

            modelBuilder.Entity<User>()
                .Property(u => u.DateCreated)
                .HasColumnType(Rule.User.DateCreated.DATA_TYPE)
                .HasDefaultValueSql(Rule.User.DateCreated.DEFAULT_VALUE_SQL);

            modelBuilder.Entity<User>()
               .Property(u => u.DateModified)
               .HasColumnType(Rule.User.DateModified.DATA_TYPE)
               .HasDefaultValueSql(Rule.User.DateModified.DEFAULT_VALUE_SQL);

            modelBuilder.Entity<User>()
                .Property(u => u.Status)
                .HasColumnType(Rule.User.Status.DATA_TYPE)
                .HasDefaultValue(Rule.User.Status.DEFAULT_VALUE)
                .IsRequired();
        }

        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
