using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories.Interface;
using Services.DTOs.Product;
using Services.Services.Interfaces;

namespace CoffeeApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(statusCode:StatusCodes.Status200OK,Type =typeof(ProductDto))]
        [ProducesResponseType(statusCode:StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAllAsync());
        }
    }
}
