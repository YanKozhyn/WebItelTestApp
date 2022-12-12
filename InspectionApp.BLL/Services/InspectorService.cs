using AutoMapper;
using InspectionApp.BLL.DTOs;
using InspectionApp.BLL.Infrastructire;
using InspectionApp.BLL.Interfaces;
using InspectionApp.DAL.Data;
using InspectionApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace InspectonApp.BLL.Services
{
    public class InspectorService : IHelperService<InspectorDto>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public InspectorService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<IEnumerable<InspectorDto>> GetAllAsync()
        {
            try
            {
                IEnumerable<Inspector> inspectors = await _context.Inspectors.ToListAsync();
                IEnumerable<InspectorDto> InspectorDto = _mapper.Map<IEnumerable<Inspector>, IEnumerable<InspectorDto>>(inspectors);
                return InspectorDto;
            }
            catch (Exception ex)
            {
                throw new ValidationException($"{ex.Message}", "");
            }
        }

        public async Task<InspectorDto> GetByIdAsync(int id)
        {
            var inspector = await _context.Inspectors!.FindAsync(id);

            if (inspector == null)
            {
                throw new ValidationException($"Not Inspector with id: {id}", "");
            }
            return _mapper.Map<Inspector, InspectorDto>(inspector);
        }

        public async Task UpdateAsync(int id, InspectorDto InspectorDto)
        {
            if (!InspectorExists(id))
            {
                throw new ValidationException("Inspector with this id ain't exist", "");
            }
            var inspector = _mapper.Map<InspectorDto, Inspector>(InspectorDto);
            _context.Entry(inspector).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<InspectorDto> CreateAsync(InspectorDto InspectorDto)
        {
            try
            {
                var Inspector = _mapper.Map<InspectorDto, Inspector>(InspectorDto);
                _context.Inspectors!.Add(Inspector);
                await _context.SaveChangesAsync();
                var newInspectorDto = _mapper.Map<Inspector, InspectorDto>(Inspector);
                return newInspectorDto;
            }
            catch (Exception ex)
            {
                throw new ValidationException($"{ex.Message}", "");
            }
        }


        public async Task<InspectorDto> DeleteAsync(int id)
        {
            var inspector = await _context.Inspectors!.FindAsync(id);
            if (inspector == null)
            {
                throw new ValidationException("Not found", "");
            }

            _context.Inspectors.Remove(inspector);
            await _context.SaveChangesAsync();
            var InspectorDto = _mapper.Map<InspectorDto>(inspector);
            return InspectorDto;

        }
        private bool InspectorExists(int id)
        {
            return _context.Inspectors!.Any(e => e.Id == id);
        }

    }
}
