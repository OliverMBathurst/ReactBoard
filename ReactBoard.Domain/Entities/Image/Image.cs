using ReactBoard.Domain.Common;

namespace ReactBoard.Domain.Entities.Image
{
    public class Image : Entity<long>, IImage
    {
        public Image() { }

        public string Location { get; set; }        
    }
}