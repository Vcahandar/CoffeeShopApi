using FluentValidation;
using Services.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validations.Category
{
    public class UpdateDtoValidator:AbstractValidator<CategoryUpdateDto>
    {
        public UpdateDtoValidator()
        {
            RuleFor(s => s.Name).NotNull().NotEmpty().MaximumLength(100);

        }
    }
}
