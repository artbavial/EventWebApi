using EventWebApi.Context;
using EventWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventWebApi.Controllers
{
    [ApiController]
    [Route("[event]")]
    public class EventController : ControllerBase
    {

        PostgreDBContext db = new PostgreDBContext();


        private readonly ILogger<EventController> _logger;

        public EventController(ILogger<EventController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetEvents")]
        public IEnumerable<Event> Get()
        {
            return new List<Event>(db.Events.AddAsync()).ToList();
        }

        

        [HttpPost]
        public string Post(Event _event)
        {
            db.Events.Add(_event);
            db.SaveChanges();
            return "Событие добавлено.";
        }
    }
}