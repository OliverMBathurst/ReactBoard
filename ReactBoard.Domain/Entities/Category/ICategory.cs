using ReactBoard.Domain.Common;

namespace ReactBoard.Domain.Entities.Category
{
    public interface ICategory : IEntity<int>
    {
        string Name { get; set; }
    }
}