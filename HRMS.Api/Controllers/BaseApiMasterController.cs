using HRMS.Application.Interfaces;
using HRMS.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseApiMasterController<T> : ControllerBase where T : BaseEntity
    {
        protected readonly IBaseService<T> _service;

        public BaseApiMasterController(IBaseService<T> service)
        {
            _service = service;
        }

        // GET: api/[controller] - Get all records (optionally show deleted)
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] bool showDeleted = false)
        {
            var entities = await _service.GetAllAsync(showDeleted);
            return Ok(entities);
        }

        // GET: api/[controller]/{id} - Get single record by ID
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        // POST: api/[controller] - Create a new record
        [HttpPost("[Action]")]
        public async Task<IActionResult> Create([FromBody] T entity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            entity.Id = Guid.NewGuid(); // Assign new ID
            await _service.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        // PUT: api/[controller]/{id} - Update an existing record
        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] T entity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != entity.Id) return BadRequest("ID mismatch");

            var existingEntity = await _service.GetByIdAsync(id);
            if (existingEntity == null) return NotFound();

            await _service.UpdateAsync(entity);
            return Ok(entity);
        }

        // DELETE: api/[controller]/{id} - Soft delete a record
        [HttpDelete("Edit/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.SoftDeleteAsync(id);
            return NoContent();
        }

        // POST: api/[controller]/{id}/restore - Restore a soft-deleted record
        [HttpPost("restore/{id}")]
        public async Task<IActionResult> Restore(Guid id)
        {
            await _service.RestoreAsync(id);
            return Ok();
        }
    }
}
