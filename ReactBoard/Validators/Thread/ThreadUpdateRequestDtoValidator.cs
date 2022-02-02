using FluentValidation;
using ReactBoard.Domain.Entities.Thread;
using ReactBoard.Models.Thread;
using System.Threading.Tasks;

namespace ReactBoard.Validators.Thread
{
    public class ThreadUpdateRequestDtoValidator : AbstractValidator<ThreadUpdateRequestDto>,
        IAsynchronousValidator<ThreadUpdateRequestDto>
    {
        private readonly IThreadService _threadService;

        public ThreadUpdateRequestDtoValidator(IThreadService threadService) 
        {
            _threadService = threadService;

            RuleFor(x => x).CustomAsync(async (dto, ctx, _) => await ValidateDto(dto, ctx));
        }

        public async Task ValidateDto(ThreadUpdateRequestDto dto, ValidationContext<ThreadUpdateRequestDto> context)
        {
            if (dto == null)
            {
                context.AddFailure(nameof(ThreadUpdateRequestDto), "Null DTO");
            }
            else
            {
                var thread = await _threadService.GetByIdAsync(dto.ThreadId);
                if (thread == null)
                {
                    context.AddFailure(nameof(ThreadUpdateRequestDto.ThreadId), "Invalid Thread identifier");
                }
            }
        }
    }
}
