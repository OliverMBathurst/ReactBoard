namespace ReactBoard.ImageAPI.Domain.Entities
{
    public interface IImageData
    {
        byte[] Bytes { get; set; }

        IImageMetadata Metadata { get; set; }
    }
}
