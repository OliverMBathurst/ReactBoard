using System;
using System.IO;
using System.Threading.Tasks;

namespace ReactBoard.ImageAPI.Domain.Services.Misc
{
    public class EncodingService : IEncodingService
    {
        public async Task<string> GetBase64EncodedStringAsync(string fileLocation)
        {
            if (string.IsNullOrWhiteSpace(fileLocation) || !File.Exists(fileLocation))
                return null;

            return Convert.ToBase64String(await File.ReadAllBytesAsync(fileLocation));
        }
    }
}
