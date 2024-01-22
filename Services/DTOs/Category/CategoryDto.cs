using Services.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Category
{
    public class CategoryDto:ActionDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
