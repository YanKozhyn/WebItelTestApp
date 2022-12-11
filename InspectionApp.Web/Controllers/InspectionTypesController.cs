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

        // GET: api/Inspections
        [HttpGet]
        public async Task<IActionResult> GetInspections()
            => Ok(await _inspectionTypeService.GetAllAsync());

        // GET: api/Inspections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InspectionTypeDto>> GetInspections(int id)
            => Ok(await _inspectionTypeService.GetByIdAsync(id));

        // PUT: api/Inspections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> PutInspection(int id, InspectionTypeDto inspectionTypeDto)
        {
            await _inspectionTypeService.UpdateAsync(id, inspectionTypeDto);
            return NoContent();
        }

        // POST: api/Inspections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InspectionTypeDto>> PostInspection(InspectionTypeDto inspectionTypeDto)
        {
            await _inspectionTypeService.CreateAsync(inspectionTypeDto);
            return CreatedAtAction(nameof(GetInspections), new { id = inspectionTypeDto.Id }, inspectionTypeDto);
        }

        // DELETE: api/Inspections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInspection(int id)
        {
            await _inspectionTypeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
