using AutoMapper;
using Domain.Models;
using Services.DTOs.Product;

namespace Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName,opt=> opt.MapFrom(src=>src.Category.Name))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => Convert.ToBase64String(src.Image)));


        }
    }
}
