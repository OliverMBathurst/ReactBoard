using ReactChan.Domain.Common;
using ReactChan.Domain.Entities.Image;
using System;
using _Image = ReactChan.Domain.Entities.Image.Image;

namespace ReactChan.Domain.Services.Image
{
    public class ImageService : EntityService<_Image, Guid>, IImageService
    {
        public ImageService(IEntityRepository<_Image, Guid> repository) : base(repository) { }
    }
}