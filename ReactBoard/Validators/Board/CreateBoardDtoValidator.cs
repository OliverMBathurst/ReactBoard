using FluentValidation;
using ReactBoard.API.Models.Board;
using ReactBoard.API.Validators;
using ReactBoard.Domain.Entities.Board;
using System.Linq;

namespace ReactBoard.API.Validators.Board
{
    public class CreateBoardDtoValidator : AbstractValidator<CreateBoardDto>,
        ISynchronousValidator<CreateBoardDto>
    {
        private readonly IBoardService _boardService;

        public CreateBoardDtoValidator(IBoardService boardService)
        {
            _boardService = boardService;

            RuleFor(x => x).Custom(ValidateDto);
        }

        public void ValidateDto(CreateBoardDto dto, ValidationContext<CreateBoardDto> context)
        {
            if (dto == null)
            {
                context.AddFailure(nameof(CreateBoardDto), "Null DTO");
            }
            else
            {
                var existingBoards = _boardService.Fetch(x => x.UrlName.Equals(dto.UrlName) || x.Name.Equals(dto.Name)).ToList();
                if (existingBoards.Any())
                {
                    context.AddFailure(nameof(CreateBoardDto), "A board already exists with a name supplied");
                }
            }
        }
    }
}
