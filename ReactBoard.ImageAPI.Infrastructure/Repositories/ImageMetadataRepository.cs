using Microsoft.EntityFrameworkCore;
using ReactBoard.ImageAPI.Domain.Entities;
using ReactBoard.ImageAPI.Infrastructure.Common;
using ReactBoard.ImageAPI.Infrastructure.DAL;
using System.Threading.Tasks;

namespace ReactBoard.ImageAPI.Infrastructure.Repositories
{
    public sealed class ImageMetadataRepository : EntityRepository<ImageMetadata, long>, IImageMetadataRepository
    {
        public ImageMetadataRepository(DatabaseContext context) : base(context) { }

        public async Task<IImageMetadata> GetByImageIdAsync(long imageId)
        {
            return await _context.Set<ImageMetadata>()
                .FirstOrDefaultAsync(x => x.ImageId.Equals(imageId));
        }
    }
}