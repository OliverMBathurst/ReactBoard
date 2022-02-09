using System.Net.Http;
using System.Threading.Tasks;

namespace ReactBoard.Domain.Interfaces
{
    public interface IHttpService
    {
        Task<T> GetAsync<T>(string endpoint);

        Task PostAsync<T>(string endpoint, T data) where T : HttpContent;
    }
}
