using InspectionApp.DAL.Entities;

namespace InspectionApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Inspection> Inspections { get; }
        IRepository<InspectionType> InspectionTypes { get; }
        IRepository<Status> Statuses { get; }
        void Save();
    }
}
