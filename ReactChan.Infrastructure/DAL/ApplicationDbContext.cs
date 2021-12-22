using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ReactChan.Domain.Entities.Board;
using ReactChan.Domain.Entities.Image;
using ReactChan.Domain.Entities.Post;
using ReactChan.Domain.Entities.Thread;
using ReactChan.Infrastructure.Models;

namespace ReactChan.Infrastructure.DAL
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Board> Boards { get; set; }

        public DbSet<Thread> Threads { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<ImageMetadata> ImageMetadata { get; set; }
    }
}
