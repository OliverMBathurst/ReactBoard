using ReactBoard.Domain.Common;

namespace ReactBoard.Domain.Entities.Image
{
    public interface IImage : IEntity<long>
    {
        string Location { get; set; }
    }
}
