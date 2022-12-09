using System.ComponentModel.DataAnnotations;

namespace API.Entity
{
    public class InspectionType : BaseEntity
    {

        [StringLength(20)]
        public string InspectionName { get; set; } = string.Empty;
    }
}
