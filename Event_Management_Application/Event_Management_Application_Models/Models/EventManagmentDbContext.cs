using Microsoft.EntityFrameworkCore;

namespace Event_Management_Application_Models.Models
{
    public class EventManagmentDbContext : DbContext
    {
        public EventManagmentDbContext(DbContextOptions<EventManagmentDbContext>options):base(options) { }
        
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Registration> Registrations { get; set; }

    }
}
