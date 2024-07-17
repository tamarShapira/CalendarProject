using Repository.Entities;
using CalendarApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Repositories.Interfaces
{
    public interface ICalendarYearRepository
    {
        Task<List<CalendarYear>> GetAllAsync();

        Task<CalendarYear> GetByIdAsync(int id);
    
        Task<CalendarYear> AddAsync( int calendarId,int year);

        Task<CalendarYear> UpdateAsync(CalendarYear calendarYear);
        

        Task DeleteAsync(int id);
    }
}

