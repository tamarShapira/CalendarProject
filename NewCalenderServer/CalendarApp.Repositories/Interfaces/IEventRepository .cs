using Repository.Entities;
using CalendarApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Repositories.Interfaces
{
    public interface IEventRepository
    {
        Task<List<Event>> GetAllAsync();

        Task<Event> GetByIdAsync(int id);
    
        Task<Event> AddAsync(int calendarId,string eventOwnerName, DateOnly gregorianDate ,string eventType, int userId,string eventYear ,bool oneTimeEvent);

        Task<Event> UpdateAsync(Event eevent);
        

        Task DeleteAsync(int id);
    }
}

