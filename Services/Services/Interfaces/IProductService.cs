using Services.DTOs.Product;

namespace Services.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(int? id);
        Task CreateAsync(ProductCreateAndUpdateDto data);
        Task UpdateAsync(int? id, ProductCreateAndUpdateDto data);
        Task DeleteAsync(int? id);
        Task SoftDeleteAsync(int id);

    }
}
