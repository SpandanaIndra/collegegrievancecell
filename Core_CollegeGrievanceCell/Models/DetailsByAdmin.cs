using System.ComponentModel.DataAnnotations;

namespace Core_CollegeGrievanceCell.Models
{
    public class DetailsByAdmin
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public string Department { get; set; }


        public User User { get; set; }
    }
}
