using ReactBoard.ImageAPI.Domain.Models;
using System.Threading.Tasks;

namespace ReactBoard.ImageAPI.Domain.Services.Api
{
    public interface IImageApiHttpService
    {
        Task<ApiImageDto> GetImageAsync(long imageId);

        Task DeleteImageAsync(long imageId);
    }
}
