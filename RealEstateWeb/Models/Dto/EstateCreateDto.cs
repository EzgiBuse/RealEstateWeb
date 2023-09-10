using System.ComponentModel.DataAnnotations;

namespace RealEstateWeb.Models.Dto
{
    public class EstateCreateDto
    {
        
            
            [Required]
            [MaxLength(50)]
            public string Name { get; set; }

            public int Occupancy { get; set; }
            public double? Msq { get; set; }
            public string? Details { get; set; }
            [Required]
            public double Rate { get; set; }

            public string? ImageURL { get; set; }

        
    }
}
