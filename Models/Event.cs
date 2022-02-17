﻿namespace EventWebApi.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string Organizer { get; set; }
        public DateTime StartTime { get; set; }
        public string Location { get; set; }
        public string Discription { get; set; }
    }
}