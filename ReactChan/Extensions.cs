using Microsoft.Extensions.DependencyInjection;
using ReactChan.Domain.Common;
using ReactChan.Domain.Entities.Board;
using ReactChan.Domain.Entities.Image;
using ReactChan.Domain.Entities.Post;
using ReactChan.Domain.Entities.Thread;
using ReactChan.Domain.Entities.User;
using ReactChan.Domain.Services.Board;
using ReactChan.Domain.Services.Image;
using ReactChan.Domain.Services.Post;
using ReactChan.Domain.Services.Thread;
using ReactChan.Domain.Services.User;
using ReactChan.Infrastructure.Common;
using ReactChan.Infrastructure.Repositories.Board;
using ReactChan.Infrastructure.Repositories.Image;
using ReactChan.Infrastructure.Repositories.Post;
using ReactChan.Infrastructure.Repositories.Thread;
using ReactChan.Infrastructure.Repositories.User;

namespace ReactChan
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
