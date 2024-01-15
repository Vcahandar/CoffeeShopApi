using Microsoft.AspNetCore.Http;


namespace Services.DTOs.Product
{
    public class ProductCreateAndUpdateDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public IFormFile Photo { get; set; }
    }
}
