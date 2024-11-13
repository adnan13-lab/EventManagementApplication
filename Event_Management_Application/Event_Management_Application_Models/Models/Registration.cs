using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Event_Management_Application_Models.Models
{
    public class Registration
    {
        [Key]
        public int RegistrationID { get; set; }

        [ForeignKey("Event")]
        public int EventID { get; set; }

        [JsonIgnore]
        public virtual Event? Event { get; set; } 

        [ForeignKey("Attendee")]
        public int AttendeeID { get; set; }

        [JsonIgnore]
        public virtual Attendee? Attendee { get; set; }
    }
}
