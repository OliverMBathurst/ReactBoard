using ReactBoard.ImageAPI.Domain.Common;

namespace ReactBoard.ImageAPI.Domain.Entities
{
    public class Image : Entity<long>, IImage
    {
        public Image() { }

        public string Location { get; set; }
    }
}