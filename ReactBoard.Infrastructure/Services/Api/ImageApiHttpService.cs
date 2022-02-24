using Microsoft.Extensions.Options;
using ReactBoard.Domain.Settings;
using ReactBoard.Infrastructure.Interfaces;
using ReactBoard.Shared.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace ReactBoard.Infrastructure.Services.Api
{
    public sealed class ImageApiHttpService : HttpService, IImageApiHttpService
    {
        private readonly string _imageEndpoint;

        public ImageApiHttpService(
            HttpClient httpClient,
            IOptions<AppSettings> options) : base(httpClient)
        {
            _imageEndpoint = options.Value.ImageAPIConnectionString;
        }

        public async Task<ApiImageDto> GetImageAsync(long imageId)
        {
            return await GetAsync<ApiImageDto>($"{_imageEndpoint}/image/{imageId}");
        }

        public async Task DeleteImageAsync(long imageId)
        {
            await DeleteAsync($"{_imageEndpoint}/image/{imageId}");
        }

        public async Task<long> GetEntityCountAsync()
        {
            return await GetAsync<long>($"{_imageEndpoint}/image/count");
        }
    }
}
