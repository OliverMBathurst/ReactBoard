using Microsoft.EntityFrameworkCore;
using ReactBoard.Domain.Entities.Category;
using ReactBoard.Infrastructure.Common;
using ReactBoard.Infrastructure.DAL;
using System.Threading.Tasks;
using _Category = ReactBoard.Domain.Entities.Category.Category;

namespace ReactBoard.Infrastructure.Repositories.Category
{
    public class CategoryRepository : EntityRepository<_Category, int>, ICategoryRepository
    {
        public CategoryRepository(DatabaseContext context) : base(context) { }

        public async Task<ICategory> GetByNameAsync(string name)
        {
            return await _context.Set<_Category>()
                .FirstOrDefaultAsync(x => x.Name.Equals(name));
        }
    }
}