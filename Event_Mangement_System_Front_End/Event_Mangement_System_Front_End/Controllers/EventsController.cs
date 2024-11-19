using Event_Mangement_System_Front_End.Models;
using Event_Mangement_System_Front_End.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Event_Mangement_System_Front_End.Controllers
{
    [Route("Events")]
    public class EventsController : Controller
    {
        private readonly EventRepository _eventRepository;

        public EventsController(EventRepository eventRepository)
        {
            this._eventRepository = eventRepository;
        }

        [HttpGet("GetEvents")]
        public async Task <IActionResult> GetEvents()
        {
            var response = await _eventRepository.GetEventList();

            if (response == null)
            {
                ViewData["ListMassage"] = "Event Is Empty";
            }
            return View(response!.Value);
        }

        [HttpGet("AddEvent")]
        public async Task <IActionResult> AddEvent()
        {
            var response = await _eventRepository.GetAttendeeList();
            ViewBag.attendee = response.Value;
            return View();
        }

        [HttpPost("AddEvent")]
        public IActionResult AddEvent(Event events)
        {
            if (ModelState.IsValid) {

                var response = _eventRepository.AddEvent(events);
                
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
        public async Task<ActionResult> FilterEventbyDate(string date)
        {
            if (ModelState.IsValid)
            {
                var response = await _eventRepository.FilterEventbyDate(date);
                ViewBag.date = response.Value;
                return View();
            }
            return View();
        }

        [HttpGet("UpdateEvent/{id}")]
        public async Task<IActionResult> UpdateEvent(int id)
        {
            var response = await _eventRepository.UpdateEvent(id);
            return View(response.Value);
        }

        [HttpPost("UpdateEvent/{id}")]
        public IActionResult UpdateEvent(int id , Event events)
        {
            if (ModelState.IsValid) {
                var response = _eventRepository.UpdateEvent(id,events);
                return RedirectToAction("GetEvents");
            }
            return View();

        }

        [Route("DeleteEvent/{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            await _eventRepository.DeleteEvent(id);
            return RedirectToAction("GetEvents");
        }

        [Route("SoftDelete/{id}")]
        public  IActionResult SoftDelete(int id)
        {
            var response =  _eventRepository.SoftDelete(id);
            return RedirectToAction("GetEvents");
        }

    }
}
