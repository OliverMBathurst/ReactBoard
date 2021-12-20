namespace ReactChan.Domain.Entities.Image
{
    public interface IImageMetadata
    {
        float Size { get; set; }

        int Width { get; set; }

        int Height { get; set; }
    }
}
