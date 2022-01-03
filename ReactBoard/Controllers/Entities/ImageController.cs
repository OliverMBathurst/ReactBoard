using Microsoft.AspNetCore.Mvc;
using ReactBoard.Controllers.Abstract;
using ReactBoard.Domain.Entities.Image;

namespace ReactBoard.Controllers.Entities
{
    [ApiController]
    public class ImageController : EntityApiController<Image, ImageKey>
    {
        public ImageController(IImageService imageService) : base(imageService) { }
    }
}