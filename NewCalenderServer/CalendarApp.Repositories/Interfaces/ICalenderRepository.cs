using Repository.Entities;
using CalendarApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Repositories.Interfaces
{
    public interface ICalendarRepository
    {
        Task<List<Calendar>> GetAllAsync();

        Task<Calendar> GetByIdAsync(int id);
    
        Task<Calendar> AddAsync( int directorId,string groupName);

        Task<Calendar> UpdateAsync(Calendar calendar);

        Task<List<Calendar>> GetCalendarsBySiteUserId(int siteUserId);

        Task<List<CalendarUser>> GetUsersByCalendar( int calendarId);
        Task DeleteAsync(int id);
    }
}

