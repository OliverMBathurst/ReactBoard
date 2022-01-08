using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.Category;
using System.Threading.Tasks;
using _Category = ReactBoard.Domain.Entities.Category.Category;

namespace ReactBoard.Domain.Services.Category
{
    public class CategoryService : EntityService<_Category, int>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) : base(categoryRepository) 
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ICategory> GetByNameAsync(string name)
        {
            return await _categoryRepository.GetByNameAsync(name);
        }
    }
}
