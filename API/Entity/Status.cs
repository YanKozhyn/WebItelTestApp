using System.ComponentModel.DataAnnotations;

namespace API.Entity
{
    public class Status : BaseEntity
    { 
        [StringLength(20)]
        public string StatusOption { get; set; } = string.Empty;
    }
}
