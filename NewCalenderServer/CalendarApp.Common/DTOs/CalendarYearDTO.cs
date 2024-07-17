using CalendarApp.Common.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Repositories.Entities
{
    public class CalendarYearDTO
    {
        public int Id { get; set; }
        public int CalendarId { get; set; }
        public int Year { get; set; }


        public CalendarDTO Calendar { get; set; }
    }
}
