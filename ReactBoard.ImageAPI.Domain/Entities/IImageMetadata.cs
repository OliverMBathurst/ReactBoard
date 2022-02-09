using ReactBoard.ImageAPI.Domain.Common;

namespace ReactBoard.ImageAPI.Domain.Entities
{
    public interface IImageMetadata : IEntity<long>
    {
        long ImageId { get; set; }

        float Size { get; set; }

        int Width { get; set; }

        int Height { get; set; }
    }
}
