using ReactBoard.Shared.Models;
using System.Threading.Tasks;

namespace ReactBoard.Infrastructure.Interfaces
{
    public interface IImageApiHttpService
    {
        Task<ApiImageDto> GetImageAsync(long imageId);

        Task DeleteImageAsync(long imageId);

        Task<long> GetEntityCountAsync();
    }
}
