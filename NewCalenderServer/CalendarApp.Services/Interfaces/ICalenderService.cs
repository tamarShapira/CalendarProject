using CalendarApp.Common.DTOs;
using CalendarApp.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Services.Interfaces
{
    public interface ICalendarService
    {
        Task<IEnumerable<CalendarDTO>> GetListAsync();

        Task<CalendarDTO> GetByIdAsync(int id);

        Task<CalendarDTO> AddAsync(CalendarDTO calendar);

        Task<CalendarDTO> UpdateAsync(CalendarDTO calendar);

        Task DeleteAsync(int id);

        Task<IEnumerable<CalendarDTO>> GetCalendarsBySiteUserId(int siteUserId);
        Task<IEnumerable<CalendarUserDTO>> GetUsersByCalendar( int calendarId);
    }
}
