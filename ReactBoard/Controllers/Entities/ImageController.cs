using Microsoft.AspNetCore.Mvc;
using ReactBoard.Controllers.Abstract;
using ReactBoard.Domain.Entities.Image;

namespace ReactBoard.Controllers.Entities
{
    [Route("[controller]")]
    public class ImageController : EntityApiController<Image, long>
    {
        public ImageController(IImageService imageService) : base(imageService) { }
    }
}