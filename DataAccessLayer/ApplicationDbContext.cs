using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sidekick.NET.Constant.Validation;

namespace DataAccessLayer
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetCategory(modelBuilder);
            SetMessage(modelBuilder);
            SetProduct(modelBuilder);
            SetUser(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void SetCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .HasMaxLength(Rule.Category.Name.MAX_LENGTH)
                .IsUnicode()
                .IsRequired();

            modelBuilder.Entity<Category>()
                .Property(c => c.FontAwesomeIconName)
                .HasMaxLength(Rule.Category.FontAwesomeIconName.MAX_LENGTH)
                .IsUnicode(false);

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

        private static void SetMessage(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .Property(m => m.Id)
                .HasDefaultValueSql(Rule.Message.Id.DEFAULT_VALUE_SQL);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SenderId);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverId);

            modelBuilder.Entity<Message>()
                .Property(m => m.DateSent)
                .HasColumnType(Rule.Message.DateSent.DATA_TYPE)
                .HasDefaultValueSql(Rule.Message.DateSent.DEFAULT_VALUE_SQL);
        }

        private static void SetProduct(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Grantor)
                .WithMany(u => u.Products)
                .HasForeignKey(p => p.GrantorId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

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

        private static void SetUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
              .Property(u => u.Address)
              .HasMaxLength(Rule.User.Address.MAX_LENGTH)
              .IsUnicode();

            modelBuilder.Entity<User>()
                .Property(u => u.ProfilePhotoURL)
                .HasMaxLength(Rule.User.ProfilePhotoURL.MAX_LENGTH)
                .IsUnicode();

            modelBuilder.Entity<User>()
                .Property(u => u.DateCreated)
                .HasColumnType(Rule.User.DateCreated.DATA_TYPE)
                .HasDefaultValueSql(Rule.User.DateCreated.DEFAULT_VALUE_SQL);

            modelBuilder.Entity<User>()
                .Property(u => u.DateModified)
                .HasColumnType(Rule.User.DateModified.DATA_TYPE)
                .HasDefaultValueSql(Rule.User.DateModified.DEFAULT_VALUE_SQL);

            modelBuilder.Entity<User>()
                .Property(u => u.LastSeen)
                .HasColumnType(Rule.User.LastSeen.DATA_TYPE)
                .HasDefaultValueSql(Rule.User.LastSeen.DEFAULT_VALUE_SQL);

            modelBuilder.Entity<User>()
                .Property(u => u.Status)
                .HasColumnType(Rule.User.Status.DATA_TYPE)
                .HasDefaultValue(Rule.User.Status.DEFAULT_VALUE);
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
    }
}
