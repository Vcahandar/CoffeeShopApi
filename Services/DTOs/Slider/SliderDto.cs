using Services.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Slider
{
    public class SliderDto:ActionDto
    {
        public string Image { get; set; }
        public string Title { get; set; }
    }
}
