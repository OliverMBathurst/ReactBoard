using Microsoft.AspNetCore.Mvc;
using ReactBoard.ImageAPI.Domain.Entities;
using ReactBoard.ImageAPI.Domain.Services.Misc;
using ReactBoard.ImageAPI.Models;
using System.Threading.Tasks;

namespace ReactBoard.ImageAPI.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageEntityService _imageEntityService;
        private readonly IImageDeletionService _imageDeletionService;
        private readonly IImageMetadataService _imageMetadataService;
        private readonly IEncodingService _encodingService;

        public ImageController(
            IImageEntityService imageEntityService,
            IImageDeletionService imageDeletionService,
            IImageMetadataService imageMetadataService,
            IEncodingService encodingService)
        {
            _imageEntityService = imageEntityService;
            _imageDeletionService = imageDeletionService;
            _imageMetadataService = imageMetadataService;
            _encodingService = encodingService;
        }

        [HttpDelete]
        [Route("{imageId}")]
        public async Task<IActionResult> DeleteImage([FromRoute] long imageId)
        {
            var image = await _imageEntityService.GetByIdAsync(imageId);
            if (image == null)
                return NotFound();

            await _imageEntityService.DeleteAsync(imageId);
            await _imageDeletionService.DeleteImageAsync(image.Location);

            return Ok();
        }

        [HttpPost]
        [Route("{imageId}")]
        public async Task<IActionResult> GetImage([FromRoute] long imageId)
        {
            var image = await _imageEntityService.GetByIdAsync(imageId);
            if (image == null)
                return NotFound();

            var metadata = await _imageMetadataService.GetByImageIdAsync(imageId);
            var encoded = await _encodingService.GetBase64EncodedStringAsync(image.Location);

            var dto = new ApiImageDto
            {
                Data = encoded,
                Metadata = new ApiImageMetadataDto(metadata)
            };

            return Ok(dto);
        }
    }
}