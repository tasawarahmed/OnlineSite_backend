using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class FurnishingType : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}