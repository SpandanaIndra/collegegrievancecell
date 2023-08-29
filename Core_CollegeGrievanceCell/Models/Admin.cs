using System.ComponentModel.DataAnnotations;

namespace Core_CollegeGrievanceCell.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Designation { get; set; }

    }
}
