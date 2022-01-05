using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReactBoard.Domain.Entities.Board;
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

            //Key setups
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<UserRoleMapping>().HasKey(x => x.Id);
            modelBuilder.Entity<Board>().HasKey(x => x.Id);
            modelBuilder.Entity<BoardAdminMapping>().HasKey(x => new { x.UserId, x.BoardId });
            modelBuilder.Entity<Thread>().HasKey(x => new { x.Id, x.BoardId });
            modelBuilder.Entity<Post>().HasKey(x => new { x.Id, x.ThreadId, x.BoardId });
            modelBuilder.Entity<Image>().HasKey(x => x.Id);
            modelBuilder.Entity<ImageMetadata>().HasKey(x => x.Id);

            //Delete behaviour
            modelBuilder.Entity<Post>()
                .HasOne<Image>()
                .WithOne()
                .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Image>()
                .HasOne<ImageMetadata>()
                .WithOne()
                .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<User>()
                .HasOne<UserRoleMapping>()
                .WithOne()
                .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<User>()
                .HasOne<BoardAdminMapping>()
                .WithOne()
                .OnDelete(DeleteBehavior.ClientCascade);

            //Auto-generation of PKs
            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<UserRoleMapping>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Board>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<BoardAdminMapping>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Thread>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Post>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Image>()
                .Property(i => i.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<ImageMetadata>()
                .Property(i => i.Id)
                .ValueGeneratedOnAdd();

            //Conversions
            modelBuilder.Entity<User>()
                .Property(x => x.Role)
                .HasConversion(new EnumToStringConverter<UserRole>());
        }
    }
}