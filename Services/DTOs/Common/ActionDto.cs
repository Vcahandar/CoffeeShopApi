using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Common
{
    public class ActionDto
    {
        public DateTime CreatedAt { get; set; }
        public bool SoftDelete { get; set; }
    }
}
