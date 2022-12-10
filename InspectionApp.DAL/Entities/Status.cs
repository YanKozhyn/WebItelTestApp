using System.ComponentModel.DataAnnotations;

namespace InspectionApp.DAL.Entities
{
    public class Status : BaseEntity
    { 
        [StringLength(20)]
        public string StatusOption { get; set; } = string.Empty;
    }
}
