using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ReactBoard.ImageAPI.Domain.Entities;

namespace ReactBoard.ImageAPI.Infrastructure.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Image> Images { get; set; }

        public DbSet<ImageMetadata> ImageMetadata { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Table mappings
            modelBuilder.Entity<Image>().ToTable("Image");
            modelBuilder.Entity<ImageMetadata>().ToTable("ImageMetadata");

            //Key setups
            modelBuilder.Entity<Image>().HasKey(x => x.Id);
            modelBuilder.Entity<ImageMetadata>().HasKey(x => x.Id);

            //Delete behaviour
            modelBuilder.Entity<Image>()
                .HasOne<ImageMetadata>()
                .WithOne()
                .HasForeignKey<ImageMetadata>(x => x.ImageId)
                .OnDelete(DeleteBehavior.ClientCascade);

            //Auto-generation of PKs
            modelBuilder.Entity<Image>().Property(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd()
                .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
            modelBuilder.Entity<ImageMetadata>().Property(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd()
                .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        }
    }
}