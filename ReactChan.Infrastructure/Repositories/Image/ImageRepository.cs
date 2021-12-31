using Microsoft.EntityFrameworkCore;
using ReactChan.Domain.Entities.Image;
using ReactChan.Infrastructure.Common;
using ReactChan.Infrastructure.DAL;
using System;
using System.Threading.Tasks;
using _Image = ReactChan.Domain.Entities.Image.Image;

namespace ReactChan.Infrastructure.Repositories.Image
{
    public class ImageRepository : EntityRepository<_Image, Guid>, IImageRepository
    {
        private readonly IImageDeletionService _imageDeletionService;

        public ImageRepository(
            ApplicationDbContext context, 
            IImageDeletionService imageDeletionService) : base(context)
        {
            _imageDeletionService = imageDeletionService;
        }

        public override async Task DeleteAsync(Guid id) 
        {
            var removal = await _context.Set<_Image>()
                .Include(x => x.Metadata)
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