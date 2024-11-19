using Event_Mangement_System_Front_End.Models;
using Microsoft.AspNetCore.Mvc;

namespace Event_Mangement_System_Front_End.Services.Data
{
    public interface IEventRepository
    {
        public Task<ActionResult<List<Event>>> GetEventList();

        public Task<ActionResult<List<Attendee>>> GetAttendeeList();

        public Task AddEvent(Event events);

        public Task<ActionResult<List<Event>>> FilterEventbyDate(string date);

        public Task<ActionResult<Event>> UpdateEvent(int id);

        public Task UpdateEvent(int id, Event events);

        public Task DeleteEvent(int id);

        public Task SoftDelete(int id);
    }
}
