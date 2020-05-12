using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UpmeetApp.Models;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace UpmeetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private DAL dal;

        public EventController(IConfiguration config)
        {
            dal = new DAL(config.GetConnectionString("default"));
        }

        [HttpGet] //api/Event
        public IEnumerable<Event> GetAllEvents()
        {
            IEnumerable<Event> result = dal.GetAllEvents();

            return result;
        }

        [HttpGet("{id}")] //api/Event
        public Event GetEventByID(int id)
        {
            Event result = dal.GetEventByID(id);
            return result;
        }

        [HttpPost]
        public int AddEvent(Event singleEvent)
        {
            int result = dal.AddEvent(singleEvent);
            return result;
        }

        [HttpDelete("{id}")]
        public int DeleteEvent(int id)
        {
            int result = dal.DeleteEventByID(id);
            return result;
        }

    }
}