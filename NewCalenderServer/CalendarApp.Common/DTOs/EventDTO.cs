using CalendarApp.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Common.DTOs
{
    public class EventDTO
    {
        public int Id { get; set; }
        public int CalendarId { get; set; }
        public string EventOwnerName  { get; set; }
        public DateOnly GregorianDate { get; set; }
        public string EventType { get; set; }
        
    
        public int UserId { get; set; }
        public string EventYear { get; set; }
        public bool OneTimeEvent { get; set; }


        public CalendarDTO Calendar { get; set; }
        public UserDTO User { get; set; }
    }
}
