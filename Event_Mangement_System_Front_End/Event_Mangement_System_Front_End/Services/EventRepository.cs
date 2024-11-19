using Event_Mangement_System_Front_End.Models;
using Event_Mangement_System_Front_End.Services.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Event_Mangement_System_Front_End.Services
{
    public class EventRepository : IEventRepository
    {
        public string URL = "https://localhost:7261/api/Event";
        private readonly HttpClient _httpClient;

        public EventRepository(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<ActionResult<List<Event>>> GetEventList()
        {
          var response = await _httpClient.GetFromJsonAsync<List<Event>>(URL);
           return response!;
        }   
        public async Task<ActionResult<List<Attendee>>> GetAttendeeList()
        {
          var response = await _httpClient.GetFromJsonAsync<List<Attendee>>("https://localhost:7261/api/Attendee");
           return response!;
        }
        public async Task AddEvent(Event events)
        {
           var response =  await _httpClient.PostAsJsonAsync(URL, events);
        }

        public async Task<ActionResult<List<Event>>> FilterEventbyDate(string date)
        {
            var response = await _httpClient.GetFromJsonAsync<List<Event>>(URL);
            var FilterDate = response!.Where(e => e.Date == date).ToList();
            return FilterDate;
        }

        public async Task<ActionResult<Event>> UpdateEvent(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Event>($"{URL}/{id}");
            return response!;
        }

        public async Task UpdateEvent(int id, Event events)
        {
            var response = await _httpClient.PutAsJsonAsync<Event>($"{URL}/{id}", events);
        }

        public async Task DeleteEvent(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Event>($"{URL}/{id}");

             await _httpClient.DeleteAsync($"{URL}/{id}");

        }
        public async Task SoftDelete(int id)
        {
            var response = await _httpClient.PatchAsync($"https://localhost:7261/api/Event/SoftDelete/{id}", null);
        }

    }
}
