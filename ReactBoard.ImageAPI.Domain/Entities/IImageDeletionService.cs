using System.Threading.Tasks;

namespace ReactBoard.ImageAPI.Domain.Entities
{
    public interface IImageDeletionService
    {
        Task DeleteImageAsync(string location);
    }
}
