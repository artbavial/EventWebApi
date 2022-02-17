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
            return db.Events.ToList();
        }

        // GET api/Event/5
        [HttpGet("{id}")]
        public Event Get(int id)
        {
            return db.Events.Find(id);
        }

        // POST api/Event
        [HttpPost]
        public string Post([FromBody] Event _event)
        {
            db.Events.Add(_event);
            db.SaveChanges();
            return "Событие добавлено.";
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
            return $"Событие с id{id} Успешно удалено";
        }
    }
}
