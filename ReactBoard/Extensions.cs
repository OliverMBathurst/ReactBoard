using Microsoft.Extensions.DependencyInjection;
using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.Board;
using ReactBoard.Domain.Entities.Image;
using ReactBoard.Domain.Entities.Post;
using ReactBoard.Domain.Entities.Thread;
using ReactBoard.Domain.Entities.User;
using ReactBoard.Domain.Services.Board;
using ReactBoard.Domain.Services.Image;
using ReactBoard.Domain.Services.Post;
using ReactBoard.Domain.Services.Thread;
using ReactBoard.Domain.Services.User;
using ReactBoard.Infrastructure.Common;
using ReactBoard.Infrastructure.Repositories.Board;
using ReactBoard.Infrastructure.Repositories.Image;
using ReactBoard.Infrastructure.Repositories.Post;
using ReactBoard.Infrastructure.Repositories.Thread;
using ReactBoard.Infrastructure.Repositories.User;

namespace ReactBoard
{
    public static class Extensions
    {
        public static void AddDependencies(this IServiceCollection collection) 
        {
            AddServices(collection);
            AddRepositories(collection);
        }

        private static void AddServices(IServiceCollection collection) 
        {
            collection.AddTransient<IBoardService, BoardService>();
            collection.AddTransient<IImageMetadataService, ImageMetadataService>();
            collection.AddTransient<IImageService, ImageService>();
            collection.AddTransient<IPostService, PostService>();
            collection.AddTransient<IThreadService, ThreadService>();
            collection.AddTransient<IUserRoleMappingService, UserRoleMappingService>();
            collection.AddTransient<IUserService, UserService>();
            collection.AddTransient<IImageDeletionService, ImageDeletionService>();
            collection.AddTransient(typeof(IEntityService<,>), typeof(EntityService<,>));
        }

        private static void AddRepositories(IServiceCollection collection) 
        {
            collection.AddTransient<IBoardAdminMappingRepository, BoardAdminMappingRepository>();
            collection.AddTransient<IBoardRepository, BoardRepository>();
            collection.AddTransient<IImageMetadataRepository, ImageMetadataRepository>();
            collection.AddTransient<IImageRepository, ImageRepository>();
            collection.AddTransient<IPostRepository, PostRepository>();
            collection.AddTransient<IThreadRepository, ThreadRepository>();
            collection.AddTransient<IUserRoleMappingRepository, UserRoleMappingRepository>();
            collection.AddTransient<IUserRepository, UserRepository>();
            collection.AddTransient(typeof(IEntityRepository<,>), typeof(EntityRepository<,>));
        }
    }
}