using System.ComponentModel.DataAnnotations;

namespace EventWebApi.Models
{
    public class Event : BaseEntity
    {
        public string EventName { get; set; }
        public string Organizer { get; set; }
        public DateTime StartTime { get; set; }
        public string Location { get; set; }
        public string Discription { get; set; }
    }
}
