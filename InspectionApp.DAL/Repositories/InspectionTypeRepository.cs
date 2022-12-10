using InspectionApp.DAL.Data;
using InspectionApp.DAL.Entities;
using InspectionApp.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InspectionApp.DAL.Repositories
{
    public class InspectionTypeRepository : IRepository<InspectionType>
    {
        private readonly DataContext _dataContext;
        public InspectionTypeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IEnumerable<InspectionType> GetAll()
            => _dataContext.InspectionTypes!;
        public InspectionType Get(int id)
            => _dataContext.InspectionTypes!.Find(id)!;
        public void Create(InspectionType InspectionType)
            => _dataContext.InspectionTypes!.Add(InspectionType);
        public IEnumerable<InspectionType> Find(Func<InspectionType, bool> predicate)
            => _dataContext.InspectionTypes!.Where(predicate).ToList();
        public void Update(InspectionType InspectionType)
            => _dataContext.Entry(InspectionType).State = EntityState.Modified;
        public void Delete(int id)
        {
            InspectionType inspectionType = _dataContext.InspectionTypes!.Find(id)!;
            if (inspectionType != null)
                _dataContext.InspectionTypes.Remove(inspectionType);
        }
    }
}
