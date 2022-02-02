using FluentValidation;
using ReactBoard.Domain.Entities.Category;
using ReactBoard.Models.Category;
using System.Threading.Tasks;

namespace ReactBoard.Validators.Category
{
    public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>, 
        IAsynchronousValidator<CreateCategoryDto>
    {
        private readonly ICategoryService _categoryService;

        public CreateCategoryDtoValidator(ICategoryService categoryService) 
        {
            _categoryService = categoryService;

            RuleFor(x => x).CustomAsync(async (dto, ctx, _) => await ValidateDto(dto, ctx));
        }

        public async Task ValidateDto(CreateCategoryDto dto, ValidationContext<CreateCategoryDto> context)
        {
            if (dto == null)
            {
                context.AddFailure(nameof(CreateCategoryDto), "Null DTO");
            }
            else if (string.IsNullOrWhiteSpace(dto.Name))
            {
                context.AddFailure(nameof(CreateCategoryDto.Name), "Invalid category name");
            }
            else
            {
                var match = await _categoryService.GetByNameAsync(dto.Name);
                if (match != null)
                {
                    context.AddFailure(nameof(CreateCategoryDto.Name), "A Category already exists with that name");
                }
            }
        }
    }
}