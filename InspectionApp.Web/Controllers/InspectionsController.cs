using InspectionApp.BLL.DTOs;
using InspectionApp.BLL.Interfaces;
using InspectionApp.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class InspectionsController : BaseApiController
    {
        private readonly IHelperService<InspectionDto> _inspectionService;

        public InspectionsController(IHelperService<InspectionDto> inspectionService)
        {
            _inspectionService = inspectionService;
        }

        // GET: api/Inspections
        [HttpGet]
        public async Task<IActionResult> GetInspections()
            => Ok(await _inspectionService.GetAllAsync());

        // GET: api/Inspections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InspectionDto>> GetInspections(int id)
            => Ok(await _inspectionService.GetByIdAsync(id));

        // PUT: api/Inspections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> PutInspection(int id, InspectionDto inspectionDto)
        {
            await _inspectionService.UpdateAsync(id, inspectionDto);
            return NoContent();
        }

        // POST: api/Inspections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InspectionDto>> PostInspection(InspectionDto inspectionDto)
        {
            await _inspectionService.CreateAsync(inspectionDto);
            return CreatedAtAction(nameof(GetInspections), new { id = inspectionDto.Id }, inspectionDto);
        }

        // DELETE: api/Inspections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInspection(int id)
        {
            await _inspectionService.DeleteAsync(id);
            return NoContent();
        }
    }
}
