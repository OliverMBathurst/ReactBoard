using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.Category;
using _Category = ReactBoard.Domain.Entities.Category.Category;

namespace ReactBoard.Domain.Services.Category
{
    public class CategoryService : EntityService<_Category, int>, ICategoryService
    {
        public CategoryService(ICategoryRepository categoryRepository) : base(categoryRepository) { }
    }
}
