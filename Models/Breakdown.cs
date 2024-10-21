using System.ComponentModel.DataAnnotations;

namespace RNRAPP.Models
{
    public class Breakdown
    {
        [Key]
        public int Id { get; set; }

        public string BreakdownReference { get; set; }  //Unique String
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string DriverName { get; set; }

        public string RegistrationNumber { get; set; }

        public DateTime BreakdownDate { get; set; } 
    }
}
