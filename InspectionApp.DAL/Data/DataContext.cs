using InspectionApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace InspectionApp.DAL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Inspection>? Inspections { get; set; }
        public DbSet<InspectionType>? InspectionTypes { get; set; }
        public DbSet<Status>? Statuses { get; set; }
        public DbSet<Inspector>? Inspectors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inspector>()
                .HasIndex(x => x.IdentificationNumber)
                .IsUnique(unique: true);

            modelBuilder.Entity<Inspection>()
            .HasOne<Inspector>(s => s.Inspector)
            .WithMany(g => g.Inspections)
            .HasForeignKey(s => s.InspectorId);
        }

    }
}
