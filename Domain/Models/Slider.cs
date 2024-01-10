using Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Slider:BaseEntity
    {
        public string Title { get; set; }
        public byte[] Image  { get; set; }
    }
}
