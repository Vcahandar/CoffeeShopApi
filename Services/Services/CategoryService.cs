using AutoMapper;
using Domain.Models;
using Domain.Models.Common.Constants;
using Domain.Models.Common.Exceptions;
using Repository.Repositories.Interface;
using Services.DTOs.Category;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepo,IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task CreateAsync(CategoryCreatedDto categoryCreateDto)
        {
            ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);

            await _categoryRepo.CreateAsync(_mapper.Map<Category>(categoryCreateDto));


        }

        public async Task DeleteAsync(int? id) => await _categoryRepo.DeleteAsync(await _categoryRepo.GetByIdAsync(id));
       

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CategoryDto>>(await _categoryRepo.GetAllAsync());
        }

        public async Task<CategoryDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            
            Category existCategory=await _categoryRepo.GetByIdAsync(id);

            return existCategory is null ? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage) : _mapper.Map<CategoryDto>(existCategory);

        }

        public async Task<IEnumerable<CategoryDto>> SearchAsync(string? searchText)
        {
            if (string.IsNullOrEmpty(searchText))
                return _mapper.Map<IEnumerable<CategoryDto>>(await _categoryRepo.FindAllAsycn());
            return _mapper.Map<IEnumerable<CategoryDto>>(await _categoryRepo.FindAllAsycn(m => m.Name.Contains(searchText)));
        }

        public async Task SoftDeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            Category existCategory = await _categoryRepo.GetByIdAsync(id)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);
            await _categoryRepo.SoftDeleteAsync(existCategory);
        }

        public async Task UpdateAsync(int? id, CategoryUpdateDto categoryUpdateDto)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            ArgumentNullException.ThrowIfNull(categoryUpdateDto, ExceptionResponseMessages.ParametrNotFoundMessage);

            Category existCategory = await _categoryRepo.GetByIdAsync(id) ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            _mapper.Map(categoryUpdateDto, existCategory);
            await _categoryRepo.UpdateAsync(existCategory);
        }
    }
}
