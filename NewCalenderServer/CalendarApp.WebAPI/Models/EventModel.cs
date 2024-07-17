using CalendarApp.Common.DTOs;
using CalendarApp.Context.Migrations;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Repositories.Entities
{
    public class EventModel
    {
        public int CalendarId { get; set; }
        public string EventOwnerName { get; set; }
        public string GregorianDate { get; set; }
        public string EventType { get; set; }
        public int UserId { get; set; }
        public string EventYear { get; set; }
        public bool OneTimeEvent { get; set; }

       
    }
}
