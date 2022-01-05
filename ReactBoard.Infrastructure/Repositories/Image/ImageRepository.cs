using Microsoft.EntityFrameworkCore;
using ReactBoard.Domain.Entities.Image;
using ReactBoard.Infrastructure.Common;
using ReactBoard.Infrastructure.DAL;
using System.Threading.Tasks;
using _Image = ReactBoard.Domain.Entities.Image.Image;

namespace ReactBoard.Infrastructure.Repositories.Image
{
    public sealed class ImageRepository : EntityRepository<_Image, long>, IImageRepository
    {
        private readonly IImageDeletionService _imageDeletionService;

        public ImageRepository(
            DatabaseContext context, 
            IImageDeletionService imageDeletionService) : base(context)
        {
            _imageDeletionService = imageDeletionService;
        }

        public override async Task DeleteAsync(long id)
        {
            var removal = await _context.Set<_Image>()
                .FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (removal != null) 
            {
                _context.Remove(removal);
                await _context.SaveChangesAsync();

                await _imageDeletionService.DeleteImageAsync(removal.Location);
            }
        }
    }
}