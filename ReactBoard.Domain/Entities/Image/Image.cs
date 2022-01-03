using ReactBoard.Domain.Common;

namespace ReactBoard.Domain.Entities.Image
{
    public class Image : Entity<ImageKey>, IImage
    {
        public Image(ImageKey key) : base(key) { }

        public string Location { get; set; }

        public IImageMetadata Metadata { get; set; }
    }
}
