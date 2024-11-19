using Event_Mangement_System_Front_End.Models;
using Event_Mangement_System_Front_End.Services.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Event_Mangement_System_Front_End.Services
{
    public class AttendeeRepository : IAttendeeRepository
    {
        public readonly HttpClient _httpClient;

        public string URL = "https://localhost:7261/api/Attendee";

        public AttendeeRepository(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<ActionResult<List<Attendee>>> GetAttendees()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Attendee>>(URL);
            return response!;
        }

        public async Task<HttpResponseMessage> SignUp(Attendee attendee)
        {
            var response = await _httpClient.PostAsJsonAsync<Attendee>(URL, attendee);
            return response;
        }

        public async Task<HttpResponseMessage> Login(Login login)
        {
            var response = await _httpClient.PostAsJsonAsync<Login>("https://localhost:7261/api/Attendee/FilterByEmail", login);
            return response;
        }

        public async Task<ActionResult<Attendee>> UpdateAttendee(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Attendee>($"{URL}/{id}");
            return response!;
        }

        public async Task<HttpResponseMessage> UpdateAttendee(int id, Attendee attendee)
        {
            var response = await _httpClient.PutAsJsonAsync<Attendee>($"{URL}/{id}", attendee);
            return response!;
        }

        public async Task<ActionResult<Attendee>> HardDelete(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Attendee>($"{URL}/{id}");
            if (response != null)
            {
                await _httpClient.DeleteAsync($"{URL}/{id}");
            }
            return response!;
        }

        public async Task<HttpResponseMessage> SoftDelete(int id)
        {
            var response = await _httpClient.PatchAsync($"https://localhost:7261/api/Attendee/SoftDelete/{id}", null);
            return response;
        }
    }
}
