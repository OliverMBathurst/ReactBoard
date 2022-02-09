using ReactBoard.ImageAPI.Domain.Common;

namespace ReactBoard.ImageAPI.Domain.Entities
{
    public class ImageMetadata : Entity<long>, IImageMetadata
    {
        public ImageMetadata() { }

        public long ImageId { get; set; }

        public float Size { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}