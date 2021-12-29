using Microsoft.AspNetCore.Mvc;
using ReactChan.Controllers.Abstract;
using ReactChan.Domain.Entities.Image;
using System;

namespace ReactChan.Controllers.Entities
{
    [ApiController]
    public class ImageController : EntityApiController<IImage, Guid>
    {
        public ImageController(IImageService imageService) : base(imageService) { }
    }
}