using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs
{
    public class CityDTO
    {
        [Required (ErrorMessage = "Name is required.")]
        [StringLength(2, ErrorMessage = "Name shoud not be more than 2 characters long.")]
        public string cityName { get; set; }
        public int cityID { get; set; }
        [Required]
        public string Country { get; set; }

    }
}
