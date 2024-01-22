using Services.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Slider
{
    public class SliderListDto:ActionDto    
    {
        public int Id { get; set; }
        public List<string> Image { get; set; }
        public string Title { get; set; }
    }
}
