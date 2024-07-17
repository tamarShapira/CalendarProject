using CalendarApp.Repositories.Entities;
using CalendarApp.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Services.Interfaces
{
    public interface ICalendarUserService
    {
        Task<IEnumerable<CalendarUserDTO>> GetListAsync(int userId);

        Task<CalendarUserDTO> GetByIdAsync(int id);

        Task<CalendarUserDTO> AddAsync(CalendarUserDTO calendarUser);

        Task<CalendarUserDTO> UpdateAsync(CalendarUserDTO calendarUser);

        Task DeleteAsync(int id);
    }
}
