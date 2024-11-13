using System.ComponentModel.DataAnnotations;

namespace Event_Mangement_System_Front_End.Models
{
    public class Registration
    {
        public int RegistrationID { get; set; }

        [Required]
        public string? name { get; set; }

        [Required]
        public string? email { get; set; }

        [Required]
        public string? events { get; set; }

        [Required]
        public string? date { get; set; }
    }
}
