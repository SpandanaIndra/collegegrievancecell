using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core_CollegeGrievanceCell.Models
{
    public class Complaint
    {
        [Key]
        public int ComplaintId { get; set; }

      
        public int UsersId { get; set; }


        public string ComplaintType { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime DateOfComplaint { get; set; }
        public string Status { get; set; }
        public string Dept { get; set; }


    }
}
