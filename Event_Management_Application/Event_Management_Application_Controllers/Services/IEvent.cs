using Event_Management_Application_Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management_Application_Controllers.Services
{
    public interface IEvent
    {
        public Task<ActionResult<List<Event>>> GetEventList();

        public Task<ActionResult<Event>> GetEventListById(int id);

        public Task<ActionResult<Event>> AddEvent(Event Events);

        public Task<ActionResult<Event>> UpDateEvent(int id, Event Events);

        public Task<ActionResult<Event>> DeleteEvent(int id);
    }
}
