using Event_Mangement_System_Front_End.Models;
using Event_Mangement_System_Front_End.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Event_Mangement_System_Front_End.Controllers
{
    [Route("Events")]
    public class EventsController : Controller
    {
        private readonly HttpClient _httpClient;

        public string URL = "https://localhost:7261/api/Event";
        public Logger? logger = Logger.instance();

        public EventsController(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        [HttpGet("GetEvents")]
        public async Task<IActionResult> GetEvents()
        {

            logger?.Log("User Visited Events Page");

            var response = await _httpClient.GetFromJsonAsync<List<Event>>(URL);
            

            if (response == null)
            {
                ViewData["ListMassage"] = "Event Is Empty";
            }
            return View(response);
        }

        [HttpGet("AddEvent")]
        public async Task<IActionResult> AddEvent()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Attendee>>("https://localhost:7261/api/Attendee");
            ViewBag.attendee = response!.ToList();
            return View();
        }

        [HttpPost("AddEvent")]
        public async Task<IActionResult> AddEvent(Event events)
        {
            if (ModelState.IsValid) {

                var response = await _httpClient.PostAsJsonAsync(URL,events);
                
                return RedirectToAction("GetEvents");
            }
            return View();
        }

        [HttpGet("FilterEventbyDate")]
        public IActionResult FilterEventbyDate()
        {
            return View();
        }

        [HttpPost("FilterEventbyDate")]
        public async Task<IActionResult> FilterEventbyDate(string date)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.GetFromJsonAsync<List<Event>>(URL);
                var FilterDate = response!.Where(e => e.Date == date).ToList();
                ViewBag.date = FilterDate;
                return View();
            }
            return View();
        }

        [HttpGet("UpdateEvent/{id}")]
        public async Task<IActionResult> UpdateEvent(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Event>($"{URL}/{id}");

            ViewData["title"] = response!.Title;
            ViewData["date"] = response.Date;
            ViewData["location"] = response.Location;

            return View();

        }

        [HttpPost("UpdateEvent/{id}")]
        public async Task<IActionResult> UpdateEvent(int id , Event events)
        {
            if (ModelState.IsValid) {
                var response = await _httpClient.PutAsJsonAsync<Event>($"{URL}/{id}", events);
                return RedirectToAction("GetEvents");
            }
            return View();

        }

        [Route("DeleteEvent/{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Event>($"{URL}/{id}");

            if (response != null)
            {
               await _httpClient.DeleteAsync($"{URL}/{id}");
            }
            else
            {
                return Json("Event Not Found");
            }
            return RedirectToAction("GetEvents");
        }

        [Route("SoftDelete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var response = await _httpClient.PatchAsync($"https://localhost:7261/api/Event/SoftDelete/{id}", null);

            return RedirectToAction("GetEvents");
        }

    }
}
