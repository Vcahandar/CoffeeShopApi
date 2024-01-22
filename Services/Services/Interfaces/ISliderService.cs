using Services.DTOs.Slider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface ISliderService
    {
        Task<IEnumerable<SliderListDto>> GetAllAsync();
        Task<SliderDto> GetByIdAsync(int? id);
        Task CreateAsync(SliderCreateDto model);
        Task UpdateAsync(int? id, SliderUpdateDto model);
        Task DeleteAsync(int? id);
    }
}
