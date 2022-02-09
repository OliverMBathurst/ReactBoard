using ReactBoard.ImageAPI.Domain.Common;

namespace ReactBoard.ImageAPI.Domain.Entities
{
    public interface IImage : IEntity<long>
    {
        string Location { get; set; }
    }
}
