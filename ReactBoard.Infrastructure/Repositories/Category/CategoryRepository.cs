using ReactBoard.Domain.Entities.Category;
using ReactBoard.Infrastructure.Common;
using ReactBoard.Infrastructure.DAL;
using _Category = ReactBoard.Domain.Entities.Category.Category;

namespace ReactBoard.Infrastructure.Repositories.Category
{
    public class CategoryRepository : EntityRepository<_Category, int>, ICategoryRepository
    {
        public CategoryRepository(DatabaseContext context) : base(context) { }
    }
}