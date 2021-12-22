using ReactChan.Domain.Entities.Image;
using ReactChan.Infrastructure.Common;
using ReactChan.Infrastructure.DAL;
using System;

namespace ReactChan.Infrastructure.Repositories.Image
{
    public class ImageMetadataRepository : EntityRepository<IImageMetadata, Guid>, IImageMetadataRepository
    {
        public ImageMetadataRepository(ApplicationDbContext context) : base(context) { }
    }
}