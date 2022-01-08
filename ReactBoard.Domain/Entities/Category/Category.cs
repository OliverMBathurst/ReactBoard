using ReactBoard.Domain.Common;

namespace ReactBoard.Domain.Entities.Category
{
    public class Category : Entity<int>, ICategory
    {
        public string Name { get; set; }
    }
}
