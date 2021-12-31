using ReactChan.Domain.Entities.Image;
using System.IO;
using System.Threading.Tasks;

namespace ReactChan.Domain.Services.Image
{
    public class ImageDeletionService : IImageDeletionService
    {
        public async Task DeleteImageAsync(string location) 
        {
            await Task.Run(() => File.Delete(location));
        }
    }
}
