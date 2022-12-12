using InspectionApp.BLL.DTOs;
using InspectionApp.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class InspectionTypesController : BaseApiController
    {
       private readonly IHelperService<InspectionTypeDto> _inspectionTypeService;

        public InspectionTypesController(IHelperService<InspectionTypeDto> inspectionTypeService)
        {
            _inspectionTypeService = inspectionTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetInspectionTypes()
            => Ok(await _inspectionTypeService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<InspectionTypeDto>> GetInspectionTypes(int id)
            => Ok(await _inspectionTypeService.GetByIdAsync(id));

        [HttpPut("{id}")]
        public async Task<ActionResult> PutInspectionType(int id, InspectionTypeDto inspectionTypeDto)
        {
            await _inspectionTypeService.UpdateAsync(id, inspectionTypeDto);
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<InspectionTypeDto>> PostInspectionType(InspectionTypeDto inspectionTypeDto)
        {
            await _inspectionTypeService.CreateAsync(inspectionTypeDto);
            return CreatedAtAction(nameof(GetInspectionTypes), new { id = inspectionTypeDto.Id }, inspectionTypeDto);
        }

        // DELETE: api/Inspections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInspectionType(int id)
        {
            await _inspectionTypeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
