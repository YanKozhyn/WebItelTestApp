namespace InspectionApp.BLL.DTOs
{
    public class InspectorDto : BaseEntityDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public int IdentificationNumber { get; set; }
        public ICollection<InspectionDto>? Inspections { get; set; }
    }
}
