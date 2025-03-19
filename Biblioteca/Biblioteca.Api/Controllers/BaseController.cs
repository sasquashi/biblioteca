using Biblioteca.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<T, TDto> 
        : ControllerBase where T 
        : class where TDto 
        : class
    {
        protected readonly BaseService<T, TDto> _service;

        protected BaseController(BaseService<T, TDto> service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            var entity = await _service.GetByIdAsync(id);
            
            if (entity == null) 
                return NotFound();

            return Ok(entity);
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            var entities = await _service.GetAllAsync();
            return Ok(entities);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = GetIdFromDto(dto) }, dto);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put(int id, [FromBody] TDto dto)
        {
            if (id != GetIdFromDto(dto)) 
                return BadRequest();

            await _service.UpdateAsync(dto);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        protected abstract int GetIdFromDto(TDto dto);
    }
}