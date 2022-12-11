using InspectionApp.DAL.Entities;

namespace InspectionApp.BLL.DTOs
{
    public class InspectionDto : BaseEntityDto
    {
        public string Status { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public int InspectionTypeId { get; set; }
        public InspectionTypeDto? InspectionType { get; set; }
    }
}