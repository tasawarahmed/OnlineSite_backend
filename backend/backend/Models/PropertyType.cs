using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class PropertyType : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}