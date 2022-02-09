using ReactBoard.ImageAPI.Domain.Entities;

namespace ReactBoard.ImageAPI.Models
{
    public sealed class ApiImageMetadataDto
    {
        public ApiImageMetadataDto() { }

        public ApiImageMetadataDto(IImageMetadata metadata)
        {
            Size = metadata.Size;
            Width = metadata.Width;
            Height = metadata.Height;
        }

        public float Size { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public void Deconstruct(out float size, out int width, out int height)
        {
            size = Size;
            width = Width;
            height = Height;
        }
    }
}
