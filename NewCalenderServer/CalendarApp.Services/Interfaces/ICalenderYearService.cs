using CalendarApp.Repositories.Entities;
using CalendarApp.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Services.Interfaces
{
    public interface ICalendarYearService
    {
        Task<IEnumerable<CalendarYearDTO>> GetListAsync();

        Task<CalendarYearDTO> GetByIdAsync(int id);

        Task<CalendarYearDTO> AddAsync(CalendarYearDTO calendarYear);

        Task<CalendarYearDTO> UpdateAsync(CalendarYearDTO calendarYear);

        Task DeleteAsync(int id);
    }
}
