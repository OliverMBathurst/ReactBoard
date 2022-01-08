using ReactBoard.Domain.Common;

namespace ReactBoard.Domain.Entities.Image
{
    public interface IImageMetadata : IEntity<long>
    {
        float Size { get; set; }

        int Width { get; set; }

        int Height { get; set; }
    }
}
