using ReactBoard.Domain.Interfaces;

namespace ReactBoard.Domain.Entities.Image
{
    public interface IImage : IEntity<ImageKey>
    {
        string Location { get; set; }

        IImageMetadata Metadata { get; set; }
    }
}
