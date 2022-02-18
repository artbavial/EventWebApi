using System.ComponentModel.DataAnnotations;

namespace EventWebApi.Models
{
    public class Event : BaseEntity
    {
        private DateTime startTime;

        public string EventName { get; set; }
        public string Organizer { get; set; }
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value.ToUniversalTime(); }
        }
        public string Location { get; set; }
        public string Discription { get; set; }
    }
}
