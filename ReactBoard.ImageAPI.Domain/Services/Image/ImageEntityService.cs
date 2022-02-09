using ReactBoard.ImageAPI.Domain.Common;
using ReactBoard.ImageAPI.Domain.Entities;
using System;
using System.IO;
using System.Threading.Tasks;
using _Image = ReactBoard.ImageAPI.Domain.Entities.Image;

namespace ReactBoard.ImageAPI.Domain.Services.Image
{
    public sealed class ImageEntityService : EntityService<_Image, long>, IImageEntityService
    {
        public ImageEntityService(IImageEntityRepository imageEntityRepository) : base(imageEntityRepository) { }

        public async Task<string> GetBase64EncodedImage(string location)
        {
            if (string.IsNullOrWhiteSpace(location) || !File.Exists(location))
                return null;

            return Convert.ToBase64String(await File.ReadAllBytesAsync(location));
        }
    }
}