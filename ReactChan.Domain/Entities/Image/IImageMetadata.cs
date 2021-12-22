using ReactChan.Domain.Interfaces;
using System;

namespace ReactChan.Domain.Entities.Image
{
    public interface IImageMetadata : IEntity<Guid>
    {
        float Size { get; set; }

        int Width { get; set; }

        int Height { get; set; }
    }
}
