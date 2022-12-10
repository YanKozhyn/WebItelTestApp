using InspectionApp.DAL.Data;
using InspectionApp.DAL.Entities;
using InspectionApp.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InspectionApp.DAL.Repositories
{
    public class StatusRepository : IRepository<Status>
    {
        private readonly DataContext _dataContext;
        public StatusRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IEnumerable<Status> GetAll()
            => _dataContext.Statuses!;
        public Status Get(int id)
            => _dataContext.Statuses!.Find(id)!;
        public void Create(Status status)
            => _dataContext.Statuses!.Add(status);
        public IEnumerable<Status> Find(Func<Status, bool> predicate)
            => _dataContext.Statuses!.Where(predicate).ToList();
        public void Update(Status status)
            => _dataContext.Entry(status).State = EntityState.Modified;
        public void Delete(int id)
        {
            Status status = _dataContext.Statuses!.Find(id)!;
            if (status != null)
                _dataContext.Statuses.Remove(status);
        }
    }
}
