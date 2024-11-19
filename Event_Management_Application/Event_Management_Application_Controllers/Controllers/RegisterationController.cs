using Microsoft.AspNetCore.Mvc;
using Event_Management_Application_Models.Models;
using Microsoft.EntityFrameworkCore;
using Event_Management_Application_Controllers.Services;

namespace Event_Management_Application_Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterationController : ControllerBase , IRegistration
    {
        public readonly EventManagmentDbContext _eventManagmentDbContext;

        public RegisterationController(EventManagmentDbContext eventManagmentDbContext) { 
        this._eventManagmentDbContext = eventManagmentDbContext;
        }


        [HttpGet("GetAllListData")]
        public ActionResult GetAllListData()
        {
            var response =  _eventManagmentDbContext.Registrations
                .Include(e => e.Event)
                .Include(e => e.Attendee)
                .Where(r => r.Event != null && r.Attendee != null)
                .Select(r => new
                {
                    name = r.Attendee!.Name,
                    email = r.Attendee.Email,
                    events = r.Event!.Title,
                    date = r.Event.Date
                }).ToList();

            if (response == null)
            {
                return NotFound("GetAllListData Empty");
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Registration>> DeleteRegistration(int id)
        {
            var response = await _eventManagmentDbContext.Registrations.FindAsync(id);
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
    }
}
