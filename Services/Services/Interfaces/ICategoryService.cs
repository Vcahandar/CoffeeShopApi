using Services.DTOs.Category;


namespace Services.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(int? id);
        Task CreateAsync(CategoryCreatedDto categoryCreateDto);
        Task DeleteAsync(int? id);
        Task UpdateAsync(int? id, CategoryUpdateDto categoryUpdateDto);
        Task<IEnumerable<CategoryDto>> SearchAsync(string? searchText);
        Task SoftDeleteAsync(int? id);
    }
}
