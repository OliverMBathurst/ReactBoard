using ReactChan.Domain.Common;
using ReactChan.Domain.Entities.Image;
using _Image = ReactChan.Domain.Entities.Image.Image;

namespace ReactChan.Domain.Services.Image
{
    public class ImageService : EntityService<_Image, ImageKey>, IImageService
    {
        public ImageService(IEntityRepository<_Image, ImageKey> repository) : base(repository) { }
    }
}