using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactBoard.Attributes;
using ReactBoard.Domain.Entities.Category;
using ReactBoard.Models.Category;
using System.Linq;
using System.Threading.Tasks;
using static ReactBoard.Domain.Entities.User.Enums;

namespace ReactBoard.Controllers
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
        [Authorise(UserRole.Admin)]
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
