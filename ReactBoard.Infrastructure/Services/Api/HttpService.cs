using ReactBoard.Domain.Interfaces;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReactBoard.Infrastructure.Services.Api
{
    public abstract class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;

        protected HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public virtual async Task<T> GetAsync<T>(string endpoint)
        {
            var result = await _httpClient.GetAsync(endpoint);
            if (!result.IsSuccessStatusCode)
            {
                //handle failure
            }

            var str = await result.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(str);
        }

        public virtual async Task PostAsync<T>(string endpoint, T data) where T : HttpContent
        {
            var result = await _httpClient.PostAsync(endpoint, data);

            if (!result.IsSuccessStatusCode)
            {
                //handle failure
            }
        }
    }
}
