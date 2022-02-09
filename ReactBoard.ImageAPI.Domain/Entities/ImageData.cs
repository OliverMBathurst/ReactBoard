namespace ReactBoard.ImageAPI.Domain.Entities
{
    public sealed class ImageData : IImageData
    {
        public byte[] Bytes { get; set; }

        public IImageMetadata Metadata { get; set; }
    }
}
