using FluentValidation;
using Services.DTOs.Slider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validations.Slider
{
    public class CreateDtoValidator: AbstractValidator<SliderCreateDto>
    {
        public CreateDtoValidator()
        {
            RuleFor(s => s.Title).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(s => s.Photo).NotNull().NotEmpty();
        }
    }
}
