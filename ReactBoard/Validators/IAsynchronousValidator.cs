using FluentValidation;
using System.Threading.Tasks;

namespace ReactBoard.API.Validators
{
    public interface IAsynchronousValidator<TDto>
    {
        Task ValidateDto(TDto dto, ValidationContext<TDto> context);
    }
}