using CalendarApp.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Repositories.Entities
{
    public class AuthModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int Tz { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BornDate { get; set; }
        public string GroupName { get; set; }
        public int CalendarId { get; set; }
        public Boolean IsAdmin { get; set; }


        private UserDTO _user;
        private SiteUserDTO _siteUser;
        private CalendarDTO _calendar;

        public UserDTO User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserDTO(Tz, FirstName, LastName, BornDate, PhoneNumber, Email);
                }
                return _user;
            }
        }

        public SiteUserDTO SiteUser
        {
            get
            {
                if (_siteUser == null)
                {
                    _siteUser = new SiteUserDTO(FirstName, LastName, Tz, Password);
                }
                return _siteUser;
            }
        }

        public CalendarDTO Calendar
        {
            get
            {
                if (_calendar == null)
                {
                    _calendar = new CalendarDTO();
                    _calendar.GroupName = GroupName;
                }
                return _calendar;
            }
        }
    }
}
