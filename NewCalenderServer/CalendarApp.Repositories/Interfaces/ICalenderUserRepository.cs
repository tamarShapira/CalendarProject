using Repository.Entities;
using CalendarApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Repositories.Interfaces
{
    public interface ICalendarUserRepository
    {
        Task<List<CalendarUser>> GetAllAsync();

        Task<CalendarUser> GetByIdAsync(int id);
    
        Task<CalendarUser> AddAsync( int userId, int calendarId, UserType userType);

        Task<CalendarUser> UpdateAsync(CalendarUser calendarUser);
        

        Task DeleteAsync(int id);
    }
}

