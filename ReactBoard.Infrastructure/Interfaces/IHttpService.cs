using System.Net.Http;
using System.Threading.Tasks;

namespace ReactBoard.Infrastructure.Interfaces
{
    public interface IHttpService
    {
        Task<T> GetAsync<T>(string endpoint);

        Task PostAsync<T>(string endpoint, T data) where T : HttpContent;

        Task DeleteAsync(string endpoint);
    }
}
