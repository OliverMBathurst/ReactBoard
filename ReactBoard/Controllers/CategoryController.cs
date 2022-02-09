using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactBoard.API.Models.Category;
using ReactBoard.Domain.Entities.Category;
using System.Linq;
using System.Threading.Tasks;

namespace ReactBoard.API.Controllers
{
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
        [AllowAnonymous]
        public IActionResult GetAllCategories()
        {
            return Ok(_categoryService.GetAll().ToList());
        }
    }
}
