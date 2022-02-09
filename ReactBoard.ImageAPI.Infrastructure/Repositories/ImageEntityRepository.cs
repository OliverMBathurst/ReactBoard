using ReactBoard.ImageAPI.Domain.Entities;
using ReactBoard.ImageAPI.Infrastructure.Common;
using ReactBoard.ImageAPI.Infrastructure.DAL;

namespace ReactBoard.ImageAPI.Infrastructure.Repositories
{
    public sealed class ImageEntityRepository : EntityRepository<Image, long>, IImageEntityRepository
    {
        public ImageEntityRepository(DatabaseContext context) : base(context) { }
    }
}