using System.ComponentModel.DataAnnotations;

namespace RealEstateWeb.Models.Dto
{
    public class EstateUpdateDto
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int Occupancy { get; set; }
        [Required]
        public double Msq { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public double Rate { get; set; }

        public string ImageURL { get; set; }

    }
}
