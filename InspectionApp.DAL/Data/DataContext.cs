using InspectionApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace InspectionApp.DAL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Inspection>? Inspections { get; set; }
        public DbSet<InspectionType>? InspectionTypes { get; set; }
        public DbSet<Status>? Statuses { get; set; }
    }
}
