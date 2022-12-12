using InspectionApp.BLL.DTOs;
using InspectionApp.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class InspectorController : BaseApiController
    {
       private readonly IHelperService<InspectorDto> _inspectorService;

        public InspectorController(IHelperService<InspectorDto> inspectorService)
        {
            _inspectorService = inspectorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetInspectors()
            => Ok(await _inspectorService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<InspectorDto>> GetInspectors(int id)
            => Ok(await _inspectorService.GetByIdAsync(id));

        [HttpPut("{id}")]
        public async Task<ActionResult> PutInspector(int id, InspectorDto inspectorDto)
        {
            await _inspectorService.UpdateAsync(id, inspectorDto);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<InspectorDto>> PostInspector(InspectorDto inspectorDto)
        {
            await _inspectorService.CreateAsync(inspectorDto);
            return CreatedAtAction(nameof(GetInspectors), new { id = inspectorDto.Id }, inspectorDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInspector(int id)
        {
            await _inspectorService.DeleteAsync(id);
            return NoContent();
        }
    }
}
