using ReactBoard.ImageAPI.Domain.Common;
using System.Threading.Tasks;

namespace ReactBoard.ImageAPI.Domain.Entities
{
    public interface IImageMetadataRepository : IEntityRepository<ImageMetadata, long>
    {
        Task<IImageMetadata> GetByImageIdAsync(long imageId);
    }
}