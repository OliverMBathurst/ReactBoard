using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.Image;

namespace ReactBoard.Domain.Services.Image
{
    public sealed class ImageMetadataService : EntityService<ImageMetadata, ImageKey>, IImageMetadataService
    {
        public ImageMetadataService(IImageMetadataRepository repository) : base(repository) { }
    }
}
