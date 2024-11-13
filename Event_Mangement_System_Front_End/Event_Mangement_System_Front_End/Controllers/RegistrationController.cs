using Event_Mangement_System_Front_End.Models;
using Microsoft.AspNetCore.Mvc;
namespace Event_Mangement_System_Front_End.Controllers
{
    

    public class RegistrationController : Controller
    {
        public readonly HttpClient _httpClient;

        public RegistrationController(HttpClient httpClient) {
        this._httpClient = httpClient;
        }

        public async Task<IActionResult> GetRegistrationList()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Registration>>("https://localhost:7261/api/Registeration/GetAllListData");
            return View(response);
        }
    }
}
