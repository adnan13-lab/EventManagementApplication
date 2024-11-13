using Event_Management_Application_Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management_Application_Controllers.Services
{
    public interface IAttendee
    {
        public Task<ActionResult<List<Attendee>>> GetAttendeeList();

        public Task<ActionResult<Attendee>> GetAttendeeListById(int id);

        public Task<ActionResult<Attendee>> AddAttendee(Attendee Attendees);

        public Task<ActionResult<Attendee>> UpDateAttendee(int id, Attendee Attendees);

        public Task<ActionResult<Attendee>> DeleteAttendee(int id);
    }
}
