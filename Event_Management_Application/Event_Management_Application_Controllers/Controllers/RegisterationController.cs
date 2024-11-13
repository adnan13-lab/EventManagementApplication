using Microsoft.AspNetCore.Http;
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

        //[HttpGet]
        //public async Task<ActionResult<List<Registration>>> GetRegistrationList()
        //{
        //    var response = await _eventManagmentDbContext.Registrations.ToListAsync();

        //    if (response == null)
        //    {
        //        return NotFound("Event List Empty");
        //    }
        //    else { 
        //        return Ok(response);
        //    }
        //}

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


        //[HttpGet("{id}")]
        //public async Task<ActionResult<Registration>> GetRegistrationListById(int id)
        //{
        //    var response = await _eventManagmentDbContext.Registrations.FindAsync(id);

        //    if (response == null)
        //    {
        //        return NotFound("Event Not Found");
        //    }
        //    else
        //    {
        //        return Ok(response);
        //    }
        //}

        //[HttpPost]
        //public async Task<ActionResult<Registration>> AddRegistration(Registration registration)
        //{
        //    if (registration == null)
        //    {
        //        return BadRequest("Data Is Not Correct Format");
        //    }
        //    else
        //    {
        //        var response = await _eventManagmentDbContext.Registrations.AddAsync(registration);
        //        await _eventManagmentDbContext.SaveChangesAsync();
        //        return Ok("Registeration is Added");
        //    }
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult<Registration>> UpDateRegistration(int id, Registration registration)
        //{
        //    if (registration == null)
        //    {
        //        return BadRequest("Data Is Not Correct Format");
        //    }
        //    else
        //    {
        //        var response = await _eventManagmentDbContext.Registrations.FindAsync(id);
        //        if (response == null)
        //        {
        //            return NotFound("Event Not Found");
        //        }
        //        else
        //        {
        //            response.RegistrationID = registration.RegistrationID;
        //            response.EventID = registration.EventID;
        //            await _eventManagmentDbContext.SaveChangesAsync();
        //            return Ok(response);
        //        }
        //    }
        //}
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
