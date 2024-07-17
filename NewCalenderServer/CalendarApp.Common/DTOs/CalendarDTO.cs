using CalendarApp.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Common.DTOs
{
    public class CalendarDTO
    {
        public int Id { get; set; }
        public int DirectorId { get; set; }
        public string GroupName { get; set; }


        public UserDTO Director { get; set; }
        public List<CalendarUserDTO> CalendarUsers { get; set; }
        public List<CalendarYearDTO> CalendarYears { get; set; }
        public List<EventDTO> Events { get; set; }
    }
}
