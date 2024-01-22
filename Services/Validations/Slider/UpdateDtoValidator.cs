using FluentValidation;
using Services.DTOs.Slider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validations.Slider
{
    public class UpdateDtoValidator: AbstractValidator<SliderUpdateDto>
    {
        public UpdateDtoValidator()
        {
            RuleFor(s => s.Title).NotNull().NotEmpty().MaximumLength(200);

        }
    }
}
