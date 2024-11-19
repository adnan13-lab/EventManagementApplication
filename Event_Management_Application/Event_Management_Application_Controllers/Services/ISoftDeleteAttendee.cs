using Event_Management_Application_Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management_Application_Controllers.Services
{
    public interface ISoftDeleteAttendee
    {
        public Task<ActionResult<Event>> SoftDelete(int id);
    }
}
