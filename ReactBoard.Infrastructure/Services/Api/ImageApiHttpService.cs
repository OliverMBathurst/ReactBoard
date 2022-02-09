using Microsoft.Extensions.Options;
using ReactBoard.Domain.Settings;
using ReactBoard.ImageAPI.Domain.Models;
using ReactBoard.ImageAPI.Domain.Services.Api;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReactBoard.Infrastructure.Services.Api
{
    public sealed class ImageApiHttpService : HttpService, IImageApiHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly string _imageEndpoint;

        public ImageApiHttpService(
            HttpClient httpClient,
            IOptions<AppSettings> options) : base(httpClient)
        {
            _httpClient = httpClient;
            _imageEndpoint = options.Value.ImageAPIEndpoint;
        }

        public async Task<ApiImageDto> GetImageAsync(long imageId)
        {
            var result = await _httpClient.GetAsync($"{_imageEndpoint}/image/{imageId}");
            if (!result.IsSuccessStatusCode)
            {
                //handle
            }

            var str = await result.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<ApiImageDto>(str);
        }

        public async Task DeleteImageAsync(long imageId)
        {
            await _httpClient.DeleteAsync($"{_imageEndpoint}/image/{imageId}");
        }
    }
}
