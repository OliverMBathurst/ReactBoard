using ReactChan.Models.Post;
using FluentValidation;

namespace ReactChan.Validators.Post
{
    public class CreatePostDtoValidator : AbstractValidator<CreatePostDto>
    {
        public CreatePostDtoValidator() 
        {
            RuleFor(x => x).Custom((dto, ctx) => ValidateDto(dto, ctx));
        }

        public void ValidateDto(CreatePostDto dto, ValidationContext<CreatePostDto> context)
        { 
            //todo
        }
    }
}
