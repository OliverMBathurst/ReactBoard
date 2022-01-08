using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReactBoard.Domain.Entities.Board;
using ReactBoard.Domain.Entities.Category;
using ReactBoard.Domain.Entities.Image;
using ReactBoard.Domain.Entities.Post;
using ReactBoard.Domain.Entities.Thread;
using ReactBoard.Domain.Entities.User;
using static ReactBoard.Domain.Entities.User.Enums;

namespace ReactBoard.Infrastructure.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Board> Boards { get; set; }

        public DbSet<Thread> Threads { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ImageMetadata> ImageMetadata { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Table mappings
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<UserRoleMapping>().ToTable("UserRoleMapping");
            modelBuilder.Entity<Board>().ToTable("Board");
            modelBuilder.Entity<BoardAdminMapping>().ToTable("BoardAdminMapping");
            modelBuilder.Entity<Thread>().ToTable("Thread");
            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Entity<Image>().ToTable("Image");
            modelBuilder.Entity<ImageMetadata>().ToTable("ImageMetadata");
            modelBuilder.Entity<Category>().ToTable("Category");
            //Key setups
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<UserRoleMapping>().HasKey(x => x.Id);
            modelBuilder.Entity<Board>().HasKey(x => x.Id);
            modelBuilder.Entity<BoardAdminMapping>().HasKey(x => new { x.Id, x.UserId });
            modelBuilder.Entity<Thread>().HasKey(x => new { x.Id, x.BoardId });
            modelBuilder.Entity<Post>().HasKey(x => new { x.Id, x.ThreadId, x.BoardId });
            modelBuilder.Entity<Image>().HasKey(x => x.Id);
            modelBuilder.Entity<Category>().HasKey(x => x.Id);

            //Delete behaviour
            modelBuilder.Entity<Image>()
                .HasOne<ImageMetadata>()
                .WithOne()
                .HasForeignKey<ImageMetadata>(x => x.Id);
            modelBuilder.Entity<User>()
                .HasOne<UserRoleMapping>()
                .WithOne()
                .HasForeignKey<UserRoleMapping>(x => x.Id);
            modelBuilder.Entity<BoardAdminMapping>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<BoardAdminMapping>(x => x.UserId);
            modelBuilder.Entity<BoardAdminMapping>()
                .HasOne<Board>()
                .WithOne()
                .HasForeignKey<BoardAdminMapping>(x => x.Id);
            modelBuilder.Entity<User>()
                .HasMany<BoardAdminMapping>()
                .WithOne()
                .HasForeignKey(x => x.UserId);
            modelBuilder.Entity<Post>()
                .HasOne<Image>()
                .WithOne()
                .HasForeignKey<Post>(x => x.ImageId);


            //Auto-generation of PKs
            modelBuilder.Entity<User>().Property(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd()
                .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
            modelBuilder.Entity<UserRoleMapping>().Property(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd()
                .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
            modelBuilder.Entity<Board>().Property(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd()
                .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
            modelBuilder.Entity<BoardAdminMapping>().Property(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd()
                .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
            modelBuilder.Entity<Thread>().Property(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd()
                .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
            modelBuilder.Entity<Post>().Property(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd()
                .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
            modelBuilder.Entity<Image>().Property(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd()
                .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
            modelBuilder.Entity<ImageMetadata>().Property(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd()
                .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
            modelBuilder.Entity<Category>().Property(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd()
                .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

            //Conversions
            modelBuilder.Entity<User>()
                .Property(x => x.Role)
                .HasConversion(new EnumToStringConverter<UserRole>());
        }
    }
}