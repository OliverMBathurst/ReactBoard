using ReactChan.Domain.Common;
using ReactChan.Domain.Entities.Image;
using System;

namespace ReactChan.Domain.Services.Image
{
    public class ImageMetadataService : EntityService<IImageMetadata, Guid>, IImageMetadataService
    {
        public ImageMetadataService(IEntityRepository<IImageMetadata, Guid> repository) : base(repository) { }
    }
}
