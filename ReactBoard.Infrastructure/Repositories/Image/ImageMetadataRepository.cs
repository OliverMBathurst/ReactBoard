using ReactBoard.Domain.Entities.Image;
using ReactBoard.Infrastructure.Common;
using ReactBoard.Infrastructure.DAL;

namespace ReactBoard.Infrastructure.Repositories.Image
{
    public sealed class ImageMetadataRepository : EntityRepository<ImageMetadata, int>, IImageMetadataRepository
    {
        public ImageMetadataRepository(DatabaseContext context) : base(context) { }
    }
}