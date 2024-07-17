using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CalendarApp.Repositories.Entities
{
    public class UserDTO
    {
        public int Id { get; set; }
        public int? SiteUserId { get; set; }
        public int TZ { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BornDate { get; set; }
        public int? SpouseId { get; set; }
        public int? FatherId { get; set; }
        public int? MotherId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }


        public SiteUserDTO SiteUser { get; set; }
        public UserDTO Spouse { get; set; }
        public UserDTO Father { get; set; }
        public UserDTO Mother { get; set; }
        public List<CalendarUserDTO> CalendarUsers { get; set; }


        public UserDTO() { }

        public UserDTO(int tz, string firstName, string lastName, DateTime bornDate, string phoneNumber, string email)
        {
            TZ = tz;
            FirstName = firstName;
            LastName = lastName;
            BornDate = bornDate;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
