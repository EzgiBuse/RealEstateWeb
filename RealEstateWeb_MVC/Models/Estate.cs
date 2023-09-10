using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateWeb_MVC.Models
{
    public class Estate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Details { get; set; }
        public double Rate { get; set; }
        public double Msq { get; set; }
        public int Occupancy { get; set; }
        public string ImageURL { get; set; }
    }
}
