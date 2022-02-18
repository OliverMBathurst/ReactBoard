using FluentValidation;
using ReactBoard.API.Models.Board;
using ReactBoard.Domain.Entities.Board;
using ReactBoard.Domain.Entities.Category;
using System.Linq;

namespace ReactBoard.API.Validators.Board
{
    public class CreateBoardDtoValidator : AbstractValidator<CreateBoardDto>,
        ISynchronousValidator<CreateBoardDto>
    {
        private readonly IBoardService _boardService;
        private readonly ICategoryService _categoryService;

        public CreateBoardDtoValidator(
            IBoardService boardService,
            ICategoryService categoryService)
        {
            _boardService = boardService;
            _categoryService = categoryService;

            RuleFor(x => x).Custom(ValidateDto);
        }

        public async void ValidateDto(CreateBoardDto dto, ValidationContext<CreateBoardDto> context)
        {
            if (dto == null)
            {
                context.AddFailure(nameof(CreateBoardDto), "Null DTO");
            }
            else
            {
                if (dto.Category == null)
                {
                    context.AddFailure(nameof(CreateBoardDto.Category), "Board Category cannot be null");
                }
                else
                {
                    var category = await _categoryService.GetByIdAsync(dto.Category.Id);
                    if (category == null)
                    {
                        context.AddFailure(nameof(CreateBoardDto.Category.Id), "Board Category ID is invalid");
                    }
                    else
                    {
                        var existingBoards = _boardService.Fetch(x => x.UrlName.Equals(dto.UrlName) || x.Name.Equals(dto.Name)).ToList();
                        if (existingBoards.Any())
                        {
                            context.AddFailure(nameof(CreateBoardDto), "A Board already exists with a name supplied");
                        }
                    }
                }
            }
        }
    }
}