using System.Threading.Tasks;

namespace ReactChan.Domain.Entities.Image
{
    public interface IImageDeletionService
    {
        Task DeleteImageAsync(string location);
    }
}
