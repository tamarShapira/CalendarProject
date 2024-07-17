using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Common.DTOs
{
    public class YearEventDTO
    {

        public int Id { get; set; }
        public int EventId { get; set; }
        public int CalendarId { get; set; }
        public DateTime GregorianDate { get; set; }

        public EventDTO Event { get; set; }
        public CalendarDTO Calendar { get; set; }
    }
}
