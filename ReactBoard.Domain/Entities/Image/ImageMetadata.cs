using ReactBoard.Domain.Common;

namespace ReactBoard.Domain.Entities.Image
{
    public class ImageMetadata : Entity<int>, IImageMetadata
    {
        public ImageMetadata() { }

        public long ImageId { get; set; }

        public float Size { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}