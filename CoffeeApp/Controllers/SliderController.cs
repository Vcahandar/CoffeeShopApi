using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Slider;
using Services.Services;
using Services.Services.Interfaces;
using Services.Validations.Slider;
using System.ComponentModel.DataAnnotations;

namespace CoffeeApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _service;
        public SliderController(ISliderService service)
        {
            _service = service;
        }


        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromForm] SliderCreateDto request)
        {
            try
            {
                var validation = new CreateDtoValidator().Validate(request);
                if (!validation.IsValid)
                {
                    var errors = validation.Errors.Select(error => error.ErrorMessage).ToList();
                    return BadRequest(errors);
                }

                await _service.CreateAsync(request);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(SliderUpdateDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute] int? id, [FromForm] SliderUpdateDto request)
        {
            try
            {
                var validation = new UpdateDtoValidator().Validate(request);
                if (!validation.IsValid)
                {
                    var errors = validation.Errors.Select(error => error.ErrorMessage).ToList();
                    return BadRequest(errors);
                }
                await _service.UpdateAsync(id, request);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromRoute] int? id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(SliderDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById([FromRoute] int? id)
        {
            try
            {
                return Ok(await _service.GetByIdAsync(id));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(IEnumerable<SliderDto>))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _service.GetAllAsync());
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }




        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SoftDelete([FromRoute][Required] int? id)
        {
            try
            {
                await _service.SoftDeleteAsync(id);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
