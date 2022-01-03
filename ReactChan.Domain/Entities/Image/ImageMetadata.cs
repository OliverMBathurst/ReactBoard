using ReactBoard.Domain.Common;

namespace ReactBoard.Domain.Entities.Image
{
    public class ImageMetadata : Entity<ImageKey>, IImageMetadata
    {
        public ImageMetadata(ImageKey key) : base(key) { }

        public float Size { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}
