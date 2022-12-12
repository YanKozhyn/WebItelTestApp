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
        
        [HttpGet]
        public async Task<IActionResult> GetStatuses()
            => Ok(await _statusService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<StatusDto>> GetStatuses(int id)
            => Ok(await _statusService.GetByIdAsync(id));

        [HttpPut("{id}")]
        public async Task<ActionResult> PutStatus(int id, StatusDto statusDto)
        {
            await _statusService.UpdateAsync(id, statusDto);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<StatusDto>> PostStatus(StatusDto statusDto)
        {
            await _statusService.CreateAsync(statusDto);
            return CreatedAtAction(nameof(GetStatuses), new { id = statusDto.Id }, statusDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            await _statusService.DeleteAsync(id);
            return NoContent();
        }
    }
}
