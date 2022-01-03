using ReactBoard.Domain.Entities.Image;
using System.IO;
using System.Threading.Tasks;

namespace ReactBoard.Domain.Services.Image
{
    public sealed class ImageDeletionService : IImageDeletionService
    {
        public async Task DeleteImageAsync(string location) 
        {
            await Task.Run(() => File.Delete(location));
        }
    }
}
