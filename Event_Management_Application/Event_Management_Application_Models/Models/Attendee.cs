
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Event_Management_Application_Models.Models
{
    public class Attendee
    {

        public int AttendeeID { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public int IsActive { get; set; }

        [JsonIgnore]
        public virtual ICollection<Registration>? Registration { get; set; }
    }
}
