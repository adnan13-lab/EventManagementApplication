using Event_Mangement_System_Front_End.Models;
using Microsoft.AspNetCore.Mvc;

namespace Event_Mangement_System_Front_End.Services.Data
{
    public interface IResgistrationRepository
    {
        public Task<ActionResult<List<Registration>>> GetRegistrationList();
    }
}
