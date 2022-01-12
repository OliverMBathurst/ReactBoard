using Microsoft.AspNetCore.Mvc;
using ReactBoard.Domain.Entities.Image;

namespace ReactBoard.Controllers
{
    [Route("[controller]")]
    public class ImageController : EntityApiController<Image, long>
    {
        public ImageController(IImageService imageService) : base(imageService) { }
    }
}