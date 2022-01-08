using ReactBoard.Models.Post;
using FluentValidation;
using ReactBoard.Domain.Entities.Thread;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace ReactBoard.Validators.Post
{
    public class CreatePostDtoValidator : AbstractValidator<CreatePostDto>
    {
        private readonly IThreadService _threadService;
        private readonly AppSettings _appSettings;

        public CreatePostDtoValidator(
            IThreadService threadService,
            IOptions<AppSettings> options)
        {
            _threadService = threadService;
            _appSettings = options.Value;

            RuleFor(x => x).CustomAsync(async (dto, ctx, _) => await ValidateDto(dto, ctx));
        }

        private async Task ValidateDto(CreatePostDto dto, ValidationContext<CreatePostDto> context)
        {
            if (dto == null)
            {
                context.AddFailure(nameof(CreatePostDto), "Null DTO");
            } 
            else
            {
                if (string.IsNullOrWhiteSpace(dto.Text))
                {
                    context.AddFailure(nameof(CreatePostDto.Text), "Empty Post contents");
                }
                else
                {
                    if (dto.Text.Length > _appSettings.MaxPostLength)
                    {
                        context.AddFailure(nameof(CreatePostDto.Text), "Post text length exceeds maximum length");
                    }
                    else
                    {
                        var thread = await _threadService.GetThreadAsync(dto.ThreadId, dto.BoardId);
                        if (thread == null)
                        {
                            context.AddFailure(nameof(CreatePostDto.ThreadId), "Invalid thread identifier");
                        } 
                        else if (thread.Locked)
                        {
                            context.AddFailure(nameof(CreatePostDto.ThreadId), "Thread is locked");
                        }
                    }
                }
            }
        }
    }
}