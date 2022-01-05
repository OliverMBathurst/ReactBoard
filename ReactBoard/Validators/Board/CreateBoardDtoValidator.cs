using FluentValidation;
using ReactBoard.Domain.Entities.Board;
using ReactBoard.Models.Board;
using System.Linq;

namespace ReactBoard.Validators.Board
{
    public class CreateBoardDtoValidator : AbstractValidator<CreateBoardDto>
    {
        private readonly IBoardService _boardService;

        public CreateBoardDtoValidator(IBoardService boardService)
        {
            _boardService = boardService;

            RuleFor(x => x).Custom(ValidateDto);
        }

        private void ValidateDto(CreateBoardDto dto, ValidationContext<CreateBoardDto> context)
        {
            if (dto == null)
            {
                context.AddFailure(nameof(CreateBoardDto), "Null DTO");
            }
            else
            {
                var existingBoards = _boardService.Fetch(x => x.BoardUrlName.Equals(dto.BoardUrlName) || x.Name.Equals(dto.Name)).ToList();
                if (existingBoards.Any())
                {
                    context.AddFailure(nameof(CreateBoardDto), "A board already exists with a name supplied");
                }
            }
        }
    }
}
