using AutoMapper;
using Domain.Models;
using Repository.Repositories.Interface;
using Services.DTOs.Product;
using Services.Helpers;
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
        private readonly ICategoryRepository _categoryRepo;
        public ProductService(IProductRepository productRepo,IMapper mapper,ICategoryRepository categoryRepo)
        {
             _productRepo = productRepo;
             _mapper = mapper;
            _categoryRepo = categoryRepo;
        }

        public async Task CreateAsync(ProductCreateAndUpdateDto data)
        {
            var category = await _categoryRepo.FindAllAsync(a=>a.Id==data.CategoryId);

            var mapProduct = _mapper.Map<Product>(data);

            mapProduct.Image = await data.Photo.GetBytes();

            await _productRepo.CreateAsync(mapProduct);


        }
      

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            // easy
            //var data = await _productRepo.GetAllAsync();
            //var mappedData = _mapper.Map<IEnumerable<ProductDto>>(data);

            // advance
            return _mapper.Map<IEnumerable<ProductDto>>(await _productRepo.GetAllAsync()); 
        }

        public async Task<ProductDto> GetByIdAsync(int? id) => _mapper.Map<ProductDto>(await _productRepo.GetByIdAsync(id));


        public async Task DeleteAsync(int? id) => await _productRepo.DeleteAsync(await _productRepo.GetByIdAsync(id));

        public async Task UpdateAsync(int? id, ProductCreateAndUpdateDto data)
        {

            if (id == null) throw new ArgumentNullException();

            var dbProduct = await _productRepo.GetByIdAsync(id);

            if (dbProduct == null)
            {
                throw new NullReferenceException();
            }

            _mapper.Map(data, dbProduct);
            await _productRepo.UpdateAsync(dbProduct);
        }

        public async Task SoftDeleteAsync(int id)
        {
            await _productRepo.SoftDelete(await _productRepo.GetByIdAsync(id));
        }
    }
}
