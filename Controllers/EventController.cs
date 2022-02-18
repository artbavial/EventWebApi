using EventWebApi.Context;
using EventWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        PostgreDBContext db = new PostgreDBContext();

        // GET: api/<Event>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return db.Events;
        }

        // GET api/Event/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var obj = db.Events.Find(id);
            if (obj != null)
            {

                return Ok(obj);
            }
            else
            {
                return NotFound("Not Found");
            }
        }

        // GET api/Event/Date,date
        [HttpGet("SelectBetwentDates")]
        public IEnumerable<Event> Get(DateTimeOffset start, DateTimeOffset end)
        {
            return db.Events.Where(d => d.StartTime>=start.UtcDateTime && d.StartTime<=end.UtcDateTime);
        }

        // POST api/Event
        [HttpPost]
        public string Post([FromBody] Event _event)
        {
            db.Events.Add(_event);
            db.SaveChanges();
            return "Событие успешно добавлено.";
        }

        // PUT api/Event/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Event _event)
        {
            var obj = db.Events.Find(id);
            obj.EventName = _event.EventName;
            obj.StartTime = _event.StartTime;
            obj.Organizer = _event.Organizer;
            obj.Location = _event.Location;
            obj.Discription = _event.Discription;

            db.Events.Update(obj);
            db.SaveChanges();
            return $"Обновление записи с id{id} успешно завершено.";
        }

        // DELETE api/Event/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var obj = db.Events.Find(id);
            db.Events.Remove(obj);
            db.SaveChanges();
            return $"Событие с id{id} успешно удалено";
        }
    }
}
