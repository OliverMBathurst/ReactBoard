using Microsoft.AspNetCore.Mvc;
using ReactBoard.Domain.Entities.Category;
using ReactBoard.Models.Category;
using System.Linq;
using System.Threading.Tasks;

namespace ReactBoard.Controllers.Entities
{
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewCategory([FromBody] CreateCategoryDto dto)
        {
            await _categoryService.SaveOrUpdateAsync(new Category { Name = dto.Name });
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(_categoryService.GetAll().ToList());
        }
    }
}
