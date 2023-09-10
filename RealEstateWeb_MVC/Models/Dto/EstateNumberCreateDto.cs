using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateWeb_MVC.Models.Dto
{
    public class EstateNumberCreateDto
    {
        [Required]
        public int EstateNo { get; set; }
        [Required]
        public int EstateID { get; set; }


        public string SpecialDetails { get; set; }


    }
}
