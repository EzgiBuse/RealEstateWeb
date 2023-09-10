using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateWeb_MVC.Models
{
    public class EstateNumber
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EstateNo { get; set; }

        [ForeignKey("Estate")]
        public int EstateID { get; set; }

        public Estate Estate { get; set; }
        public string SpecialDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set;}
    }
}
