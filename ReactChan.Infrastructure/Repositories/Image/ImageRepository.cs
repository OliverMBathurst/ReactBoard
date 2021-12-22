using ReactChan.Domain.Entities.Image;
using ReactChan.Infrastructure.Common;
using ReactChan.Infrastructure.DAL;
using System;

namespace ReactChan.Infrastructure.Repositories.Image
{
    public class ImageRepository : EntityRepository<IImage, Guid>, IImageRepository
    {
        public ImageRepository(ApplicationDbContext context) : base(context) { }
    }
}