using ReactBoard.ImageAPI.Domain.Common;
using ReactBoard.ImageAPI.Domain.Entities;
using System.Threading.Tasks;

namespace ReactBoard.ImageAPI.Domain.Services.Image
{
    public sealed class ImageMetadataService : EntityService<ImageMetadata, long>, IImageMetadataService
    {
        private readonly IImageMetadataRepository _imageMetadataRepository;

        public ImageMetadataService(IImageMetadataRepository imageMetadataRepository) : base(imageMetadataRepository)
        {
            _imageMetadataRepository = imageMetadataRepository;
        }

        public async Task<IImageMetadata> GetByImageIdAsync(long imageId)
        {
            return await _imageMetadataRepository.GetByImageIdAsync(imageId);
        }
    }
}
