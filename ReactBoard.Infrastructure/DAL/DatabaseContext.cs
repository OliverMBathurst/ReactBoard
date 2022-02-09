using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReactBoard.Domain.Entities.Board;
using ReactBoard.Domain.Entities.Category;
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

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Table mappings
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<UserRoleMapping>().ToTable("UserRoleMapping");
            modelBuilder.Entity<Board>().ToTable("Board");
            modelBuilder.Entity<BoardAdminMapping>().ToTable("BoardAdminMapping");
            modelBuilder.Entity<Thread>().ToTable("Thread");
            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Entity<Category>().ToTable("Category");

            //Key setups
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<UserRoleMapping>().HasKey(x => x.Id);
            modelBuilder.Entity<Board>().HasKey(x => x.Id);
            modelBuilder.Entity<BoardAdminMapping>().HasKey(x => x.Id);
            modelBuilder.Entity<Thread>().HasKey(x => x.Id);
            modelBuilder.Entity<Post>().HasKey(x => x.Id);
            modelBuilder.Entity<Category>().HasKey(x => x.Id);

            //Delete behaviour
            modelBuilder.Entity<User>()
                .HasOne<UserRoleMapping>()
                .WithOne()
                .HasForeignKey<UserRoleMapping>(x => x.UserId)
                .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<BoardAdminMapping>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<BoardAdminMapping>(x => x.UserId);
            modelBuilder.Entity<BoardAdminMapping>()
                .HasOne<Board>()
                .WithOne()
                .HasForeignKey<BoardAdminMapping>(x => x.BoardId);
            modelBuilder.Entity<User>()
                .HasMany<BoardAdminMapping>()
                .WithOne()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Thread>()
                .HasMany(x => x.Posts)
                .WithOne()
                .HasForeignKey(x => x.ThreadId)
                .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Post>()
                .HasOne<Board>()
                .WithOne()
                .HasForeignKey<Post>(x => x.BoardId);

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
            modelBuilder.Entity<Category>().Property(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd()
                .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

            //Conversions
            modelBuilder.Entity<User>()
                .Property(x => x.Role)
                .HasConversion(new EnumToStringConverter<UserRole>());
        }
    }
}