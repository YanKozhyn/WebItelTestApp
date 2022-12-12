using AutoMapper;
using InspectionApp.BLL.DTOs;
using InspectionApp.BLL.Infrastructire;
using InspectionApp.BLL.Interfaces;
using InspectionApp.DAL.Data;
using InspectionApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace InspectionApp.BLL.Services
{
    public class InspectionService : IHelperService<InspectionDto>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public InspectionService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<IEnumerable<InspectionDto>> GetAllAsync()
        {
            try
            {
                IEnumerable<Inspection> inspections = await _context.Inspections.ToListAsync();
                IEnumerable<InspectionDto> inspectionDto = _mapper.Map<IEnumerable<Inspection>, IEnumerable<InspectionDto>>(inspections);
                return inspectionDto;
            }
            catch (Exception ex)
            {
                throw new ValidationException($"{ex.Message}", "");
            }
        }

        public async Task<InspectionDto> GetByIdAsync(int id)
        {
            var inspection = await _context.Inspections!.FindAsync(id);

            if (inspection == null)
            {
                throw new ValidationException($"Not inspection with id: {id}", "");
            }
            return _mapper.Map<Inspection, InspectionDto>(inspection);
        }

        public async Task UpdateAsync(int id, InspectionDto inspectionDto)
        {
            if (!InspectionExists(id))
            {
                throw new ValidationException("Inspection with this id ain't exist", "");
            }
            var inspection = _mapper.Map<InspectionDto, Inspection>(inspectionDto);
            _context.Entry(inspection).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<InspectionDto> CreateAsync(InspectionDto inspectionDto)
        {
            try
            {
                var inspection = _mapper.Map<InspectionDto, Inspection>(inspectionDto);
                _context.Inspections!.Add(inspection);
                await _context.SaveChangesAsync();
                var newInspectionDto = _mapper.Map<Inspection, InspectionDto>(inspection);
                return newInspectionDto;
            }
            catch (Exception ex)
            {
                throw new ValidationException($"{ex.Message}", "");
            }
        }


        public async Task<InspectionDto> DeleteAsync(int id)
        {
            var inspection = await _context.Inspections!.FindAsync(id);
            if (inspection == null)
            {
                throw new ValidationException("Not found", "");
            }

            _context.Inspections.Remove(inspection);
            await _context.SaveChangesAsync();
            var inspectionDto = _mapper.Map<InspectionDto>(inspection);
            return inspectionDto;

        }
        private bool InspectionExists(int id)
        {
            return _context.Inspections!.Any(e => e.Id == id);
        }

    }
}
