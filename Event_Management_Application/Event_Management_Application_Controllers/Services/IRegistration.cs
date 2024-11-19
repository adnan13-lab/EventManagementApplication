using Event_Management_Application_Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Event_Management_Application_Controllers.Services
{
    public interface IRegistration
    {

        ActionResult GetAllListData();

        public Task<ActionResult<Registration>> DeleteRegistration(int id);
    }
}
