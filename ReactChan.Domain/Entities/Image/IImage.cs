using ReactChan.Domain.Interfaces;
using System;

namespace ReactChan.Domain.Entities.Image
{
    public interface IImage : IEntity<Guid>
    {
        string Location { get; set; }

        IImageMetadata Metadata { get; set; }
    }
}
