using InspectionApp.DAL.Data;
using InspectionApp.DAL.Entities;
using InspectionApp.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionApp.DAL.Repositories
{
    internal class InspectionRepository : IRepository<Inspection>
    {

        private readonly DataContext _dataContext;

        public InspectionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Inspection> GetAll()
            =>  _dataContext.Inspections!;
        public Inspection Get(int id)
            => _dataContext.Inspections!.Find(id)!;
        public void Create(Inspection inspection)
            => _dataContext.Inspections!.Add(inspection);
        public IEnumerable<Inspection> Find(Func<Inspection, bool> predicate)
            => _dataContext.Inspections!.Where(predicate).ToList();
        public void Update(Inspection inspection)
            => _dataContext.Entry(inspection).State = EntityState.Modified;
        public void Delete(int id)
        {
            Inspection inspection = _dataContext.Inspections!.Find(id)!;
            if (inspection != null)
                _dataContext.Inspections.Remove(inspection);
        }
        







    }
}
