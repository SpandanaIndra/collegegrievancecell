using System.ComponentModel.DataAnnotations;

namespace Core_CollegeGrievanceCell.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Department")]
        public string Department { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Please enter a valid 10-digit mobile number.")]
        public long PhoneNumber { get; set; }

        [EmailAddress]
        public string EmailID { get; set; }
        [Required]
        public string Designation { get; set; }

        // public int Id { get; set; }
        public DetailsByAdmin DetailsByAdmin { get; set; }
    }
}
