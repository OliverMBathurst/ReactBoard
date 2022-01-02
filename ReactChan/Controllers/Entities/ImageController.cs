using Microsoft.AspNetCore.Mvc;
using ReactChan.Controllers.Abstract;
using ReactChan.Domain.Entities.Image;

namespace ReactChan.Controllers.Entities
{
    [ApiController]
    public class ImageController : EntityApiController<Image, ImageKey>
    {
        public ImageController(IImageService imageService) : base(imageService) { }
    }
}