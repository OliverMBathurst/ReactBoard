using Microsoft.AspNetCore.Mvc;
using ReactBoard.Domain.Entities.Category;
using System.Linq;

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

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(_categoryService.GetAll().ToList());
        }
    }
}
