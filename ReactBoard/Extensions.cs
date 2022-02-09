using Microsoft.Extensions.DependencyInjection;
using ReactBoard.Domain.Entities.Board;
using ReactBoard.Domain.Entities.Category;
using ReactBoard.Domain.Entities.Post;
using ReactBoard.Domain.Entities.Thread;
using ReactBoard.Domain.Entities.User;
using ReactBoard.Domain.Services.Board;
using ReactBoard.Domain.Services.Category;
using ReactBoard.Domain.Services.Post;
using ReactBoard.Domain.Services.Thread;
using ReactBoard.Domain.Services.User;
using ReactBoard.ImageAPI.Domain.Services.Api;
using ReactBoard.Infrastructure.Repositories.Board;
using ReactBoard.Infrastructure.Repositories.Category;
using ReactBoard.Infrastructure.Repositories.Post;
using ReactBoard.Infrastructure.Repositories.Thread;
using ReactBoard.Infrastructure.Repositories.User;
using ReactBoard.Infrastructure.Services.Api;
using System.Net.Http;

namespace ReactBoard.API
{
    public static class Extensions
    {
        public static void AddDependencies(this IServiceCollection collection)
        {
            AddServices(collection);
            AddRepositories(collection);
            AddClients(collection);
        }

        private static void AddServices(IServiceCollection collection)
        {
            collection.AddTransient<IBoardService, BoardService>();
            collection.AddTransient<IPostService, PostService>();
            collection.AddTransient<IThreadService, ThreadService>();
            collection.AddTransient<IUserRoleMappingService, UserRoleMappingService>();
            collection.AddTransient<IUserService, UserService>();
            collection.AddTransient<ICategoryService, CategoryService>();
            collection.AddSingleton<IUserPasswordSaltingService, UserPasswordSaltingService>();
            collection.AddSingleton<IImageApiHttpService, ImageApiHttpService>();
            
        }

        private static void AddRepositories(IServiceCollection collection)
        {
            collection.AddTransient<IBoardAdminMappingRepository, BoardAdminMappingRepository>();
            collection.AddTransient<IBoardRepository, BoardRepository>();
            collection.AddTransient<IPostRepository, PostRepository>();
            collection.AddTransient<IThreadRepository, ThreadRepository>();
            collection.AddTransient<IUserRoleMappingRepository, UserRoleMappingRepository>();
            collection.AddTransient<IUserRepository, UserRepository>();
            collection.AddTransient<ICategoryRepository, CategoryRepository>();
        }

        private static void AddClients(IServiceCollection collection)
        {
            collection.AddHttpClient<HttpClient>();
        }
    }
}