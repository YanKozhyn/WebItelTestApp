using AutoMapper;
using InspectionApp.BLL.DTOs;
using InspectionApp.BLL.Infrastructire;
using InspectionApp.BLL.Interfaces;
using InspectionApp.DAL.Data;
using InspectionApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace InspectionApp.BLL.Services
{
    public class StatusService : IHelperService<StatusDto>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public StatusService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<IEnumerable<StatusDto>> GetAllAsync()
        {
            try
            {
                IEnumerable<Status> statuses = await _context.Statuses.ToListAsync();
                IEnumerable<StatusDto> statusDto = _mapper.Map<IEnumerable<Status>, IEnumerable<StatusDto>>(statuses);
                return statusDto;
            }
            catch (Exception ex)
            {
                throw new ValidationException($"{ex.Message}", "");
            }
        }

        public async Task<StatusDto> GetByIdAsync(int id)
        {
            var status = await _context.Statuses!.FindAsync(id);

            if (status == null)
            {
                throw new ValidationException($"Not inspection with id: {id}", "");
            }
            return _mapper.Map<Status, StatusDto>(status);
        }

        public async Task UpdateAsync(int id, StatusDto statusDto)
        {
            if (!InspectionExists(id))
            {
                throw new ValidationException("Inspection with this id ain't exist", "");
            }
            var status = _mapper.Map<StatusDto, Status>(statusDto);
            _context.Entry(status).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<StatusDto> CreateAsync(StatusDto statusDto)
        {
            try
            {
                var status = _mapper.Map<StatusDto, Status>(statusDto);
                _context.Statuses!.Add(status);
                await _context.SaveChangesAsync();
                var newStatusDto = _mapper.Map<Status, StatusDto>(status);
                return newStatusDto;
            }
            catch (Exception ex)
            {
                throw new ValidationException($"{ex.Message}", "");
            }
        }


        public async Task<StatusDto> DeleteAsync(int id)
        {
            var status = await _context.Statuses!.FindAsync(id);
            if (status == null)
            {
                throw new ValidationException("Not found", "");
            }
            _context.Statuses.Remove(status);
            await _context.SaveChangesAsync();
            var statusDto = _mapper.Map<StatusDto>(status);
            return statusDto;

        }
        private bool InspectionExists(int id)
        {
            return _context.Statuses!.Any(e => e.Id == id);
        }

    }
}


