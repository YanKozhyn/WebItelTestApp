using System.ComponentModel.DataAnnotations;

namespace InspectionApp.DAL.Entities
{
    public class Inspection : BaseEntity
    {
        
        [StringLength(20)]
        public string Status { get; set; } = string.Empty;
        [StringLength(200)]
        public string Comments { get; set; } = string.Empty;
        public int InspectionTypeId { get; set; }
        public int? InspectorId { get; set; }
        public Inspector? Inspector { get; set; }
        public InspectionType? InspectionType { get; set; }
       
    }
}
