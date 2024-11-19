using Event_Mangement_System_Front_End.Models;
using Microsoft.AspNetCore.Mvc;

namespace Event_Mangement_System_Front_End.Services.Data
{
    public interface IAttendeeRepository
    {
        public Task<ActionResult<List<Attendee>>> GetAttendees();
        public Task<HttpResponseMessage> SignUp(Attendee attendee);
        public Task<HttpResponseMessage> Login(Login login);
        public Task<ActionResult<Attendee>> UpdateAttendee(int id);
        public Task<HttpResponseMessage> UpdateAttendee(int id, Attendee attendee);
        public Task<ActionResult<Attendee>> HardDelete(int id);
        public Task<HttpResponseMessage> SoftDelete(int id);
    }
}
