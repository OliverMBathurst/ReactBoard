using FluentValidation;
using ReactChan.Domain.Entities.Board;
using ReactChan.Models.Board;

namespace ReactChan.Validators.Board
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
            //todo
        }
    }
}
