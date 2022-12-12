using AutoMapper;
using InspectionApp.BLL.DTOs;
using InspectionApp.BLL.Infrastructire;
using InspectionApp.BLL.Interfaces;
using InspectionApp.DAL.Data;
using InspectionApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace InspectionApp.BLL.Services
{
    public class InspectionTypeService : IHelperService<InspectionTypeDto>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public InspectionTypeService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<IEnumerable<InspectionTypeDto>> GetAllAsync()
        {
            try
            {
                IEnumerable<InspectionType> InspectionTypes = await _context.InspectionTypes.ToListAsync();
                IEnumerable<InspectionTypeDto> inspectionTypeDto = _mapper.Map<IEnumerable<InspectionType>, IEnumerable<InspectionTypeDto>>(InspectionTypes);
                return inspectionTypeDto;
            }
            catch (Exception ex)
            {
                throw new ValidationException($"{ex.Message}", "");
            }
        }

        public async Task<InspectionTypeDto> GetByIdAsync(int id)
        {
            var inspectionType = await _context.InspectionTypes!.FindAsync(id);

            if (inspectionType == null)
            {
                throw new ValidationException($"Not inspection with id: {id}", "");
            }
            return _mapper.Map<InspectionType, InspectionTypeDto>(inspectionType);
        }

        public async Task UpdateAsync(int id, InspectionTypeDto inspectionTypeDto)
        {
            if (!InspectionExists(id))
            {
                throw new ValidationException("Inspection with this id ain't exist", "");
            }
            var inspectionType = _mapper.Map<InspectionTypeDto, InspectionType>(inspectionTypeDto);
            _context.Entry(inspectionType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<InspectionTypeDto> CreateAsync(InspectionTypeDto inspectionTypeDto)
        {
            try
            {
                var inspectionType = _mapper.Map<InspectionTypeDto, InspectionType>(inspectionTypeDto);
                _context.InspectionTypes!.Add(inspectionType);
                await _context.SaveChangesAsync();
                var newInspectionTypeDto = _mapper.Map<InspectionType, InspectionTypeDto>(inspectionType);
                return newInspectionTypeDto;
            }
            catch (Exception ex)
            {
                throw new ValidationException($"{ex.Message}", "");
            }
        }


        public async Task<InspectionTypeDto> DeleteAsync(int id)
        {
            var inspectionType = await _context.InspectionTypes!.FindAsync(id);
            if (inspectionType == null)
            {
                throw new ValidationException("Not found", "");
            }
            _context.InspectionTypes.Remove(inspectionType);
            await _context.SaveChangesAsync();
            var inspectionTypeDto = _mapper.Map<InspectionTypeDto>(inspectionType);
            return inspectionTypeDto;

        }
        private bool InspectionExists(int id)
        {
            return _context.InspectionTypes!.Any(e => e.Id == id);
        }

    }
}
