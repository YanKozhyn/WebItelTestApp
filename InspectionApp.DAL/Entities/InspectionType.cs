using System.ComponentModel.DataAnnotations;

namespace InspectionApp.DAL.Entities
{
    public class InspectionType : BaseEntity
    {

        [StringLength(20)]
        public string InspectionName { get; set; } = string.Empty;
    }
}
