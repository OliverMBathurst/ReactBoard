using ReactChan.Domain.Common;
using ReactChan.Domain.Entities.Image;
using System;

namespace ReactChan.Domain.Services.Image
{
    public class ImageMetadataService : EntityService<ImageMetadata, Guid>, IImageMetadataService
    {
        public ImageMetadataService(IEntityRepository<ImageMetadata, Guid> repository) : base(repository) { }
    }
}
