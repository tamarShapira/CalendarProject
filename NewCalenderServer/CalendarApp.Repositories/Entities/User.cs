using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        public int? SiteUserId { get; set; }
        [Required]
        public int TZ { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime BornDate { get; set; }
        public int? SpouseId { get; set; }
        public int? FatherId { get; set; }
        public int? MotherId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }


        public SiteUser SiteUser { get; set; }
        public User Spouse { get; set; }
        public User Father { get; set; }
        public User Mother { get; set; }
        public List<CalendarUser> CalendarUsers { get; set; }
    }
}
