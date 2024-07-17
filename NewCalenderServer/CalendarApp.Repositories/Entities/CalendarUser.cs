using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public enum UserType
    {
        Admin,
        Editor,
        Viewer
    }

    public class CalendarUser
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int CalendarId { get; set; }
        [Required]
        public UserType UserType { get; set; }


        public User User { get; set; }
        public Calendar Calendar { get; set; }


        //[Required]
        //public int LevelId { get; set; }
        //[Required]
        //public int FamilyId { get; set; }
    }
}
