using InspectionApp.BLL.DTOs;
using InspectionApp.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class StatusController : BaseApiController
    {
       private readonly IHelperService<StatusDto> _statusService;

        public StatusController(IHelperService<StatusDto> statusService)
        {
            _statusService = statusService;
        }

        // GET: api/Inspections
        [HttpGet]
        public async Task<IActionResult> GetInspections()
            => Ok(await _statusService.GetAllAsync());

        // GET: api/Inspections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusDto>> GetInspections(int id)
            => Ok(await _statusService.GetByIdAsync(id));

        // PUT: api/Inspections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> PutInspection(int id, StatusDto statusDto)
        {
            await _statusService.UpdateAsync(id, statusDto);
            return NoContent();
        }

        // POST: api/Inspections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StatusDto>> PostInspection(StatusDto statusDto)
        {
            await _statusService.CreateAsync(statusDto);
            return CreatedAtAction(nameof(GetInspections), new { id = statusDto.Id }, statusDto);
        }

        // DELETE: api/Inspections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInspection(int id)
        {
            await _statusService.DeleteAsync(id);
            return NoContent();
        }
    }
}
