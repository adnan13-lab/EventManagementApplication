using System.ComponentModel.DataAnnotations;

namespace Event_Mangement_System_Front_End.Models
{
    public class Attendee
    {
        public int AttendeeID { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [RegularExpression("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$" , ErrorMessage ="Enter Valid Email")]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        public int IsActive { get; set; }
    }
}
