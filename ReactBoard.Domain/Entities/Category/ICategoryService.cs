using ReactBoard.Domain.Common;
using System.Threading.Tasks;

namespace ReactBoard.Domain.Entities.Category
{
    public interface ICategoryService : IEntityService<Category, int>
    {
        Task<ICategory> GetByNameAsync(string name);
    }
}
