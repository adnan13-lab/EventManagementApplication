using Event_Management_Application_Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management_Application_Controllers.Services
{
    public interface IRegistration
    {
        //public Task<ActionResult<List<Registration>>> GetRegistrationList();

        ActionResult GetAllListData();

        //public Task<ActionResult<Registration>> GetRegistrationListById(int id);

        //public Task<ActionResult<Registration>> AddRegistration(Registration registration);

        //public Task<ActionResult<Registration>> UpDateRegistration(int id, Registration registration);

        public Task<ActionResult<Registration>> DeleteRegistration(int id);
    }
}
