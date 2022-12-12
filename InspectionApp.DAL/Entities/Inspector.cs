using Microsoft.EntityFrameworkCore;

namespace InspectionApp.DAL.Entities
{
    public class Inspector : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string SecondName {get;set;} = string.Empty;
        public int IdentificationNumber { get; set; }
        public ICollection<Inspection>? Inspections { get; set; }
    }
}