using Microsoft.AspNetCore.Mvc;
using ReactBoard.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace ReactBoard.API.Controllers
{
    public class ImageController : AbstractApiController
    {
        private readonly IImageApiHttpService _imageApiHttpService;

        public ImageController(IImageApiHttpService imageApiHttpService)
        {
            _imageApiHttpService = imageApiHttpService;
        }

        [HttpGet]
        [Route("{imageId}")]
        public async Task<IActionResult> GetImage([FromRoute] long imageId)
        {
            var image = await _imageApiHttpService.GetImageAsync(imageId);
            if (image == null)
                return NotFound();

            return Ok(image);
        }

        [HttpPost]
        [Route("delete/{imageId}")]
        public async Task<IActionResult> DeleteImage([FromRoute] long imageId)
        {
            await _imageApiHttpService.DeleteImageAsync(imageId);
            return Ok();
        }

        [HttpGet]
        [Route("count")]
        public async Task<IActionResult> GetImagesCount()
        {
            return Ok(await _imageApiHttpService.GetEntityCountAsync());
        }
    }
}
