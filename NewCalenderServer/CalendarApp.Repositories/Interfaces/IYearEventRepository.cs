using Repository.Entities;
using CalendarApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Repositories.Interfaces
{
    public interface IYearEventRepository
    {
        Task<List<YearEvent>> GetAllAsync();

        Task<YearEvent> GetByIdAsync(int id);
    
        Task<YearEvent> AddAsync(int eventId,int calendarId,DateTime gregorianDate);

       // Task<int> GetByDetailsAsync(string name, string adress);
        Task<YearEvent> UpdateAsync(YearEvent yearEvent);

        Task DeleteAsync(int id);
    }
}

