using Event_Mangement_System_Front_End.Models;
using Event_Mangement_System_Front_End.Services.Data;
using Microsoft.AspNetCore.Mvc;

namespace Event_Mangement_System_Front_End.Services
{
    public class RegistrationRepository : IResgistrationRepository
    {
        public readonly HttpClient _httpClient;

        public RegistrationRepository(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<ActionResult<List<Registration>>> GetRegistrationList()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Registration>>("https://localhost:7261/api/Registeration/GetAllListData");
            return response!;
        }
    }
}
