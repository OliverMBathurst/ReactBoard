using ReactBoard.Domain.Common;

namespace ReactBoard.Domain.Entities.Image
{
    public class ImageMetadata : Entity<long>, IImageMetadata
    {
        public ImageMetadata() { }

        public float Size { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}