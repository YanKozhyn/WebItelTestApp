using InspectionApp.BLL.DTOs;

namespace InspectionApp.BLL.Interfaces
{
    public interface IHelperService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T obj);
        Task UpdateAsync(int id, T obj);
        Task<T> DeleteAsync(int id);
    }
}
