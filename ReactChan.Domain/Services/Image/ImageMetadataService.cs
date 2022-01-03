using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.Image;

namespace ReactBoard.Domain.Services.Image
{
    public class ImageMetadataService : EntityService<ImageMetadata, ImageKey>, IImageMetadataService
    {
        public ImageMetadataService(IEntityRepository<ImageMetadata, ImageKey> repository) : base(repository) { }
    }
}
