using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories.Interface;
using Services.DTOs.Product;
using Services.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

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
        [ProducesResponseType(statusCode:StatusCodes.Status200OK,Type =typeof(IEnumerable<ProductDto>))]
        [ProducesResponseType(statusCode:StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAllAsync());
        }



        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(ProductDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById([FromRoute][Required] int id)
        {
            try
            {
                return Ok(await _productService.GetByIdAsync(id));

            }
            catch (NullReferenceException ex)
            {

                return NotFound(ex.Message);
            }
            catch(ArgumentNullException ex)
            {
                return BadRequest   (ex.Message);
            }

        }


        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromForm] ProductCreateAndUpdateDto product)
        {
            try
            {
                await _productService.CreateAsync(product);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _productService.DeleteAsync(id);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute][Required] int id,[FromForm]ProductCreateAndUpdateDto product)
        {
            try
            {
                await _productService.UpdateAsync(id,product);
                return Ok();
            }
            catch(NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentNullException ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SoftDeleted([FromRoute][Required] int id)
        {
            try
            {
                await _productService.SoftDeleteAsync(id);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
