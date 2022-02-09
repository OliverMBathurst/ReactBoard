using System.Threading.Tasks;

namespace ReactBoard.ImageAPI.Domain.Services.Misc
{
    public interface IEncodingService
    {
        Task<string> GetBase64EncodedStringAsync(string fileLocation);
    }
}
