using InspectionApp.DAL.Data;
using InspectionApp.DAL.Entities;
using InspectionApp.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InspectionApp.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private DataContext? _dataContext;
        private InspectionRepository? _inspectionRepository;
        private InspectionTypeRepository? _inspectionTypeRepository;
        private StatusRepository? _statusRepository;
        public EFUnitOfWork(DbContextOptions options)
        {
            _dataContext = new DataContext(options);
        }
        public IRepository<Inspection> Inspections
        {
            get
            {
                _inspectionRepository ??= new InspectionRepository(_dataContext!);
                return _inspectionRepository;
            }
        }
        public IRepository<InspectionType> InspectionTypes
        {
            get
            {
                _inspectionTypeRepository ??= new InspectionTypeRepository(_dataContext!);
                return _inspectionTypeRepository;
            }
        }
        public IRepository<Status> Statuses
        {
            get
            {
                _statusRepository ??= new StatusRepository(_dataContext!);
                return _statusRepository;
            }
        }
        public void Save()
        {
            _dataContext!.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dataContext!.Dispose();
                }
                this.disposed = true;      
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
