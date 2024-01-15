using FluentValidation;
using Services.DTOs.Category;

namespace Services.Validations.Category
{
    public class CreateDtoValidator: AbstractValidator<CategoryCreatedDto>
    {
        public CreateDtoValidator()
        {
            RuleFor(s => s.Name).NotNull().NotEmpty().MaximumLength(100);
        }
    }
}
