using FluentValidation;
using ReactBoard.Domain.Entities.Board;
using ReactBoard.Models.Thread;
using System.Threading.Tasks;

namespace ReactBoard.Validators.Thread
{
    public class CreateThreadDtoValidator : AbstractValidator<CreateThreadDto>, 
        IAsynchronousValidator<CreateThreadDto>
    {
        private readonly IBoardService _boardService;

        public CreateThreadDtoValidator(IBoardService boardService)
        {
            _boardService = boardService;

            RuleFor(x => x).CustomAsync(async (dto, ctx, _) => await ValidateDto(dto, ctx));
        }

        public async Task ValidateDto(CreateThreadDto dto, ValidationContext<CreateThreadDto> context)
        {
            if (dto == null)
            {
                context.AddFailure(nameof(CreateThreadDto), "Null DTO");
            }
            else
            {
                if (dto.Post == null)
                {
                    context.AddFailure(nameof(CreateThreadDto.Post), "Null Post");
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(dto.Post.Text))
                    {
                        context.AddFailure(nameof(CreateThreadDto.Post.Text), "Invalid Post text");
                    }
                    else
                    {
                        var board = await _boardService.GetByIdAsync(dto.BoardId);
                        if (board == null)
                        {
                            context.AddFailure(nameof(CreateThreadDto.BoardId), "Invalid Board identifier");
                        }
                        else if (board.Threads.Count + 1 > board.MaxThreads)
                        {
                            context.AddFailure(nameof(CreateThreadDto), "Max number of threads reached");
                        }
                    }
                }
            }
        }
    }
}