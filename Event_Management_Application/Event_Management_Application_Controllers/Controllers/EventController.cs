using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Event_Management_Application_Models.Models;
using Microsoft.EntityFrameworkCore;
using Event_Management_Application_Controllers.Services;

namespace Event_Management_Application_Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase , IEvent
    {
        public readonly EventManagmentDbContext _eventManagmentDbContext;

        public EventController(EventManagmentDbContext eventManagmentDbContext) { 
        this._eventManagmentDbContext = eventManagmentDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Event>>> GetEventList()
        {
            var response = await _eventManagmentDbContext.Events.ToListAsync();

            if (response == null)
            {
                return NotFound("Event List Empty");
            }
            else { 
                return Ok(response);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEventListById(int id)
        {
            var response = await _eventManagmentDbContext.Events.FindAsync(id);

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
        public async Task<ActionResult<Event>> AddEvent(Event Events)
        {

            if (Events == null)
            {
                return BadRequest("Data Is Not Correct Format");
            }
            else
            {
                
                var response = await _eventManagmentDbContext.Events.AddAsync(Events);
                await _eventManagmentDbContext.SaveChangesAsync();

                var registration = new Registration
                {
                    EventID = Events.EventID,
                    AttendeeID = Events.At_Id,

                };

                var res = await _eventManagmentDbContext.Registrations.AddAsync(registration);
                await _eventManagmentDbContext.SaveChangesAsync();

                return Ok("Event Is Added");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Event>> UpDateEvent(int id , Event Events)
        {
            if (Events == null)
            {
                return BadRequest("Data Is Not Correct Format");
            }
            else
            {
                var response = await _eventManagmentDbContext.Events.FindAsync(id);
                if (response == null)
                {
                    return NotFound("Event Not Found");
                }
                else
                {
                    response.Title = Events.Title;
                    response.Date = Events.Date;
                    response.Location = Events.Location;

                    await _eventManagmentDbContext.SaveChangesAsync();
                    return Ok(response);
                }
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Event>> DeleteEvent(int id)
        {
            var response = await _eventManagmentDbContext.Events.FindAsync(id);
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

        [HttpPatch("SoftDelete/{id}")]
        public async Task<ActionResult<Event>> SoftDelete(int id)
        {
            var response = await _eventManagmentDbContext.Events.FindAsync(id);
            if (response == null)
            {
                return NotFound("Event Not Found");
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
