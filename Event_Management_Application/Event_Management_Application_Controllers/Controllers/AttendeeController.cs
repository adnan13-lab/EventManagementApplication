using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Event_Management_Application_Models.Models;
using Microsoft.EntityFrameworkCore;
using Event_Management_Application_Controllers.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace Event_Management_Application_Controllers.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeeController : ControllerBase , IAttendee , ISoftDeleteAttendee
    {
        public readonly EventManagmentDbContext _eventManagmentDbContext;
        private readonly IConfiguration _configuration;

        public AttendeeController(EventManagmentDbContext eventManagmentDbContext , IConfiguration configuration) { 
            this._eventManagmentDbContext = eventManagmentDbContext;
            this._configuration = configuration;
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

          var FilterData = response.Where(e => e.Email == attendee.Email && e.Password == attendee.Password).FirstOrDefault();


            if (FilterData == null)
            {
                return NotFound();
            }
            else
            {
                var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:subject"]!),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim("AttendeeID",FilterData.AttendeeID.ToString()),
                new Claim("Email",FilterData.Email),
            };

                var key = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
                var creds = new Microsoft.IdentityModel.Tokens.SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new { token = tokenString });
                //return Ok(FilterData);
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
