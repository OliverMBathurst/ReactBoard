using ReactChan.Domain.Common;
using ReactChan.Domain.Entities.Image;
using System;

namespace ReactChan.Domain.Services.Image
{
    public class ImageService : EntityService<IImage, Guid>, IImageService
    {
        public ImageService(IEntityRepository<IImage, Guid> repository) : base(repository) { }
    }
}