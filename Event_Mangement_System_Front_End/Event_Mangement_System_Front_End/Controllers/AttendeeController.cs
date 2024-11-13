using Event_Mangement_System_Front_End.Models;
using Event_Mangement_System_Front_End.Services;
using Microsoft.AspNetCore.Mvc;

namespace Event_Mangement_System_Front_End.Controllers
{
    public class AttendeeController : Controller
    {
        
        public readonly HttpClient _httpClient;
        public Logger? logger = Logger.instance();

        public string URL = "https://localhost:7261/api/Attendee";

        public AttendeeController(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }


        [HttpGet]
        public IActionResult SignUp()
        {
            logger?.Log("User Visited Sign Up Page");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAttendees()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Attendee>>(URL);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(Attendee attendee)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync<Attendee>(URL, attendee);
                return RedirectToAction("Login");
                //return RedirectToAction("GetAttendees");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            logger?.Log("User Visited Login Page");
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
                var response = await _httpClient.PostAsJsonAsync<Login>("https://localhost:7261/api/Attendee/FilterByEmail", login);
                if (response.IsSuccessStatusCode)
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
            var response = await _httpClient.GetFromJsonAsync<Attendee>($"{URL}/{id}");

            ViewData["name"] = response!.Name;
            ViewData["email"] = response.Email;

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> UpdateAttendee(int id, Attendee attendee)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PutAsJsonAsync<Attendee>($"{URL}/{id}", attendee);
                return RedirectToAction("GetAttendees");
            }
            return View();

        }

        [Route("Attendee/HardDelete/{id}")]
        public async Task<IActionResult> HardDelete(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Attendee>($"{URL}/{id}");

            if (response != null)
            {
                await _httpClient.DeleteAsync($"{URL}/{id}");
            }
            else
            {
                return Json("Event Not Found");
            }
            return RedirectToAction("GetAttendees");
        }

        [Route("Attendee/SoftDelete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var response = await _httpClient.PatchAsync($"https://localhost:7261/api/Attendee/SoftDelete/{id}",null);
           
            return RedirectToAction("GetAttendees");
        }
    }
}
