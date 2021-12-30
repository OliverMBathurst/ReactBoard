using FluentValidation;
using ReactChan.Models.Board;

namespace ReactChan.Validators.Board
{
    public class CreateBoardDtoValidator : AbstractValidator<CreateBoardDto>
    {
        public CreateBoardDtoValidator()
        {
            RuleFor(x => x).Custom(ValidateDto);
        }

        private void ValidateDto(CreateBoardDto dto, ValidationContext<CreateBoardDto> context)
        { 
            //todo
        }
    }
}
