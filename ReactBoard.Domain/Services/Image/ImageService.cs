﻿using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.Image;
using _Image = ReactBoard.Domain.Entities.Image.Image;

namespace ReactBoard.Domain.Services.Image
{
    public sealed class ImageService : EntityService<_Image, ImageKey>, IImageService
    {
        public ImageService(IImageRepository repository) : base(repository) { }
    }
}