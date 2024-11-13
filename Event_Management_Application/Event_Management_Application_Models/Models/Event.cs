
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Event_Management_Application_Models.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }

        public int At_Id { get; set; }

        public string? Title { get; set; }

        public string? Date { get; set; }

        public string? Location { get; set; }

        public int IsActive { get; set; }

        [JsonIgnore]
        public virtual ICollection<Registration>? Registration { get; set; }
    }
}
