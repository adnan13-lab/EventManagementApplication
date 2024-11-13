using System.ComponentModel.DataAnnotations;

namespace Event_Mangement_System_Front_End.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }

        [Required]
        public int At_Id { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Date { get; set; }

        [Required]
        public string? Location { get; set; }

        public int IsActive { get; set; }
    }
}
