using System.Threading.Tasks;

namespace ReactBoard.Domain.Entities.Image
{
    public interface IImageDeletionService
    {
        Task DeleteImageAsync(string location);
    }
}
