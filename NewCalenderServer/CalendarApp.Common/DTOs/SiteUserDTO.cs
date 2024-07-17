using CalendarApp.Common.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Repositories.Entities
{
    public class SiteUserDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Tz { get; set; }
        public string Password { get; set; }

        public List<UserDTO> Users { get; set; }
        public List<CalendarDTO> Calendars { get; set; }

        public SiteUserDTO(string firstName, string lastName, int tz, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Tz = tz;
            Password = password;
        }
    }
}
