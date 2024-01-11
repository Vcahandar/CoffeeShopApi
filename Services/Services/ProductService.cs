using AutoMapper;
using Repository.Repositories.Interface;
using Services.DTOs.Product;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ProductService : IProductService 
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepo,IMapper mapper)
        {
                _productRepo = productRepo;
                _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            // easy
            //var data = await _productRepo.GetAllAsync();
            //var mappedData = _mapper.Map<IEnumerable<ProductDto>>(data);

            // advance
            return _mapper.Map<IEnumerable<ProductDto>>(await _productRepo.GetAllAsync()); 
        }
    }
}
