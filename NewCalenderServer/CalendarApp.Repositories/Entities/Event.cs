using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Event
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int CalendarId { get; set; }
        public string EventOwnerName { get; set; }
        public DateOnly GregorianDate { get; set; }
        public string EventType { get; set; }
  
        [Required]
        public int UserId { get; set; }
        public string EventYear { get; set; }
        [Required]
        public bool OneTimeEvent { get; set; }


        public Calendar Calendar { get; set; }
        public User User { get; set; }
    }
}
