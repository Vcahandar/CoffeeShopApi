using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Slider
{
    public class SliderCreateDto
    {
        [Required]
        public IFormFile Photo { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
