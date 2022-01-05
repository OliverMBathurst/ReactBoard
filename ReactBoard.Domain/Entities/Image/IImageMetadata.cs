using ReactBoard.Domain.Common;

namespace ReactBoard.Domain.Entities.Image
{
    public interface IImageMetadata : IEntity<int>
    {
        long ImageId { get; set; }

        float Size { get; set; }

        int Width { get; set; }

        int Height { get; set; }
    }
}
