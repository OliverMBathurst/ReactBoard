using FluentValidation;

namespace ReactBoard.API.Validators
{
    public interface ISynchronousValidator<TDto>
    {
        void ValidateDto(TDto dto, ValidationContext<TDto> context);
    }
}
