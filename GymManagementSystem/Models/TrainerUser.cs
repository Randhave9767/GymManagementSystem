using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Models
{
    public class TrainerUser
    {
        public string? FullName { get; set; }
        public string? MobileNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? JoiningDate { get; set; }

        public string? Salary { get; set; }
    }
}
