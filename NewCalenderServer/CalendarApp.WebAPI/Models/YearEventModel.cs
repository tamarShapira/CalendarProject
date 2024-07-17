using System;

namespace CalendarApp.WebAPI.Models
{
    public class YearEventModel
    {
        public int EventId { get; set; }
        public int CalendarId { get; set; }
        public DateTime GregorianDate { get; set; }
    }
}
