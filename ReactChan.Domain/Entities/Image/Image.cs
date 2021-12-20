using ReactChan.Domain.Common;
using System;

namespace ReactChan.Domain.Entities.Image
{
    public class Image : Entity<Guid>, IImage
    {
        public Image(Guid id) : base(id) { }

        public string Location { get; set; }

        public IImageMetadata Metadata { get; set; }
    }
}
