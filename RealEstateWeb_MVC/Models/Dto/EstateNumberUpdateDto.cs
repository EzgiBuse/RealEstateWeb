using System.ComponentModel.DataAnnotations;

namespace RealEstateWeb_MVC.Models.Dto
{
    public class EstateNumberUpdateDto
    {
        [Required]
        public int EstateNo { get; set; }
        [Required]
        public int EstateID { get; set; }

        public string SpecialDetails { get; set; }


    }
}
