using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Event_Management_Application_Models.Models;
using Microsoft.EntityFrameworkCore;
using Event_Management_Application_Controllers.Services;

namespace Event_Management_Application_Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeeController : ControllerBase , IAttendee
    {
        public readonly EventManagmentDbContext _eventManagmentDbContext;

        public AttendeeController(EventManagmentDbContext eventManagmentDbContext) { 
        this._eventManagmentDbContext = eventManagmentDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Attendee>>> GetAttendeeList()
        {
            var response = await _eventManagmentDbContext.Attendees.ToListAsync();

            if (response == null)
            {
                return NotFound("Event List Empty");
            }
            else { 
                return Ok(response);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Attendee>> GetAttendeeListById(int id)
        {
            var response = await _eventManagmentDbContext.Attendees.FindAsync(id);

            if (response == null)
            {
                return NotFound("Event Not Found");
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Attendee>> AddAttendee(Attendee Attendees)
        {
            if (Attendees == null)
            {
                return BadRequest("Data Format Is Not Correct");
            }
            else
            {
                var response = await _eventManagmentDbContext.Attendees.AddAsync(Attendees);
                await _eventManagmentDbContext.SaveChangesAsync();
                return Ok("Attendee Is Added");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Attendee>> UpDateAttendee(int id , Attendee Attendees)
        {
            if (Attendees == null)
            {
                return BadRequest("Data Is Not Correct Format");
            }
            else
            {
                var response = await _eventManagmentDbContext.Attendees.FindAsync(id);
                if (response == null)
                {
                    return NotFound("Event Not Found");
                }
                else
                {
                    response.Name = Attendees.Name;
                    response.Email = Attendees.Email;
                    await _eventManagmentDbContext.SaveChangesAsync();
                    return Ok(response);
                }
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Attendee>> DeleteAttendee(int id)
        {
            var response = await _eventManagmentDbContext.Attendees.FindAsync(id);
            if (response == null)
            {
                return NotFound("Event Not Found");
            }
            else
            {
                _eventManagmentDbContext.Remove(response);
                await _eventManagmentDbContext.SaveChangesAsync();
                return Ok(response);
            }
        }

        [HttpPost("FilterByEmail")]
        public async Task<ActionResult<Event>> FilterByEmail(Attendee attendee)
        {
          var response = await _eventManagmentDbContext.Attendees.ToListAsync();

          var FilterData = response.Where(e => e.Email == attendee.Email && e.Password == attendee.Password);

            if (!FilterData.Any())
            {
                return NotFound();
            }
            else
            {
                return Ok(FilterData);
            }

        }


        [HttpPatch("SoftDelete/{id}")]
        public async Task<ActionResult<Event>> SoftDelete(int id)
        {
            var response = await _eventManagmentDbContext.Attendees.FindAsync(id);
            if (response == null)
            {
                return NotFound("Attendee Not Found");
            }
            else
            {
                response.IsActive = 1;
                await _eventManagmentDbContext.SaveChangesAsync();
                return Ok(response);
            }
        }
    }
}
