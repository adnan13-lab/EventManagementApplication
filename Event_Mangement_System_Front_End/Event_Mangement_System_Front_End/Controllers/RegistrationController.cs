using Event_Mangement_System_Front_End.Models;
using Event_Mangement_System_Front_End.Services;
using Microsoft.AspNetCore.Mvc;
namespace Event_Mangement_System_Front_End.Controllers
{
    

    public class RegistrationController : Controller
    {
        public readonly RegistrationRepository _registrationRepository;

        public RegistrationController(RegistrationRepository registrationRepository) {
        this._registrationRepository = registrationRepository;
        }

        public async Task<IActionResult> GetRegistrationList()
        {
            var response = await _registrationRepository.GetRegistrationList();
            return View(response.Value);
        }
    }
}
