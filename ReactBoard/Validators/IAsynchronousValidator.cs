using FluentValidation;
using System.Threading.Tasks;

namespace ReactBoard.Validators
{
    public interface IAsynchronousValidator<TDto>
    {
        Task ValidateDto(TDto dto, ValidationContext<TDto> context);
    }
}