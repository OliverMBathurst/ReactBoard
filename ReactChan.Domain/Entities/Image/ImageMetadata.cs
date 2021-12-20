namespace ReactChan.Domain.Entities.Image
{
    public class ImageMetadata : IImageMetadata
    {
        public float Size { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}
