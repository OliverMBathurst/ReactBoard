using FluentValidation;

namespace ReactBoard.Validators
{
    public interface ISynchronousValidator<TDto>
    {
        void ValidateDto(TDto dto, ValidationContext<TDto> context);
    }
}
