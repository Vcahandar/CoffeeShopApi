using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class SliderRepository : Repository<Slider>, ISliderRepository
    {
        public SliderRepository(AppDbContext context) : base(context) { }
       
    }
}
