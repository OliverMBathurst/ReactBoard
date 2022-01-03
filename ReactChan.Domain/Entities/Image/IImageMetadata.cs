using ReactBoard.Domain.Interfaces;

namespace ReactBoard.Domain.Entities.Image
{
    public interface IImageMetadata : IEntity<ImageKey>
    {
        float Size { get; set; }

        int Width { get; set; }

        int Height { get; set; }
    }
}
