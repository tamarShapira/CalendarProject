using CalendarApp.Common.DTOs;
using CalendarApp.Repositories.Entities;
using System;

namespace CalendarApp.WebAPI.Models
{
    public class UserModel
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
        public UserTypeDTO UserType { get; set; }

        public UserModel(CalendarUserDTO calendarUser)
        {
            UserDTO user = calendarUser.User;
            Id = user.Id;
            SiteUserId = user.SiteUserId;
            TZ = user.TZ;
            FirstName = user.FirstName;
            LastName = user.LastName;
            BornDate = user.BornDate;
            SpouseId = user.SpouseId;
            FatherId = user.FatherId;
            MotherId = user.MotherId;
            PhoneNumber = user.PhoneNumber;
            Email = user.Email;
            UserType = calendarUser.UserType;
        }
       

    }
}
