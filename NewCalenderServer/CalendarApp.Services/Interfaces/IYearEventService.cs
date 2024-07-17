using CalendarApp.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Services.Interfaces
{
    public interface IYearEventService
    {
        Task<IEnumerable<YearEventDTO>> GetListAsync();

        Task<YearEventDTO> GetByIdAsync(int id);

        Task<YearEventDTO> AddAsync(YearEventDTO yearEvent);

        Task<YearEventDTO> UpdateAsync(YearEventDTO yearEvent);
       // Task<YearEventDTO> GetOrderIdAsync(int eventId, int calendarId, DateOnly gregorianDate);

        Task DeleteAsync(int id);
    }
}
