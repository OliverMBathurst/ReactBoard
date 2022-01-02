using ReactChan.Domain.Interfaces;

namespace ReactChan.Domain.Entities.Image
{
    public interface IImage : IEntity<ImageKey>
    {
        string Location { get; set; }

        IImageMetadata Metadata { get; set; }
    }
}
