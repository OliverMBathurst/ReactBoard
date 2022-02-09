using Microsoft.Extensions.DependencyInjection;
using ReactBoard.ImageAPI.Domain.Entities;
using ReactBoard.ImageAPI.Domain.Services.Image;
using ReactBoard.ImageAPI.Domain.Services.Misc;
using ReactBoard.ImageAPI.Infrastructure.Repositories;

namespace ReactBoard.ImageAPI
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
            collection.AddTransient<IImageMetadataService, ImageMetadataService>();
            collection.AddTransient<IImageEntityService, ImageEntityService>();
            collection.AddTransient<IImageDeletionService, ImageDeletionService>();
            collection.AddTransient<IEncodingService, EncodingService>();
        }

        private static void AddRepositories(IServiceCollection collection)
        {
            collection.AddTransient<IImageMetadataRepository, ImageMetadataRepository>();
            collection.AddTransient<IImageEntityRepository, ImageEntityRepository>();
        }
    }
}