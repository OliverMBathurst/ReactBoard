using ReactChan.Domain.Common;
using ReactChan.Domain.Entities.Image;

namespace ReactChan.Domain.Services.Image
{
    public class ImageMetadataService : EntityService<ImageMetadata, ImageKey>, IImageMetadataService
    {
        public ImageMetadataService(IEntityRepository<ImageMetadata, ImageKey> repository) : base(repository) { }
    }
}
