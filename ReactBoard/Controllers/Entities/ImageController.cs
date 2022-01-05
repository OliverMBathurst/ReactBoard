using ReactBoard.Controllers.Abstract;
using ReactBoard.Domain.Entities.Image;

namespace ReactBoard.Controllers.Entities
{
    public class ImageController : EntityApiController<Image, long>
    {
        public ImageController(IImageService imageService) : base(imageService) { }
    }
}