using ReactChan.Domain.Entities.Image;
using ReactChan.Infrastructure.Common;
using ReactChan.Infrastructure.DAL;

namespace ReactChan.Infrastructure.Repositories.Image
{
    public class ImageMetadataRepository : EntityRepository<ImageMetadata, ImageKey>, IImageMetadataRepository
    {
        public ImageMetadataRepository(ApplicationDbContext context) : base(context) { }
    }
}