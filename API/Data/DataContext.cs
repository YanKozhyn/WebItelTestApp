using API.Entity;
using Microsoft.EntityFrameworkCore;

namespace API.Data
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
