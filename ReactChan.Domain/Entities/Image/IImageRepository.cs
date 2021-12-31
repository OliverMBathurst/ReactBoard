using ReactChan.Domain.Common;
using System;

namespace ReactChan.Domain.Entities.Image
{
    public interface IImageRepository : IEntityRepository<Image, Guid>
    {
    }
}
