using Event_Mangement_System_Front_End.Models;
using Event_Mangement_System_Front_End.Services;
using Microsoft.AspNetCore.Mvc;

namespace Event_Mangement_System_Front_End.Controllers
{
    public class AttendeeController : Controller
    {
        
        public readonly AttendeeRepository _attendeeRepository;

        public AttendeeController(AttendeeRepository attendeeRepository)
        {
            this._attendeeRepository = attendeeRepository;
        }


        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAttendees()
        {
            var response = await _attendeeRepository.GetAttendees();
            return View(response.Value);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(Attendee attendee)
        {
            if (ModelState.IsValid)
            {
                var response = await _attendeeRepository.SignUp(attendee);
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult ShowError()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var response = await _attendeeRepository.Login(login);
                if (response != null)
                {
                    return RedirectToAction("GetAttendees");
                }
                else
                {
                    return RedirectToAction("ShowError");
                }

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAttendee(int id)
        {
            var response = await _attendeeRepository.UpdateAttendee(id);

            ViewData["name"] = response.Value!.Name;
            ViewData["email"] = response.Value!.Email;

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> UpdateAttendee(int id, Attendee attendee)
        {
            if (ModelState.IsValid)
            {
                var response = await _attendeeRepository.UpdateAttendee(id,attendee);
                return RedirectToAction("GetAttendees");
            }
            return View();

        }

        [Route("Attendee/HardDelete/{id}")]
        public async Task<IActionResult> HardDelete(int id)
        {
            var response = await _attendeeRepository.HardDelete(id);
            return RedirectToAction("GetAttendees");
        }

        [Route("Attendee/SoftDelete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var response = await _attendeeRepository.SoftDelete(id);
            return RedirectToAction("GetAttendees");
        }
    }
}
