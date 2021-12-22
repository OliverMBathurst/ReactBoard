using ReactChan.Domain.Common;
using System;

namespace ReactChan.Domain.Entities.Image
{
    public class ImageMetadata : Entity<Guid>, IImageMetadata
    {
        public ImageMetadata(Guid id) : base(id) { }

        public float Size { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}
