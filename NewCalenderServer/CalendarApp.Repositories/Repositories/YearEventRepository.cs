using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using CalendarApp.Repositories;
using CalendarApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Repositories.Repositories
{
    public class YearEventRepository : IYearEventRepository
    {
        readonly IContext _context;

        public YearEventRepository(IContext context)
        {
            _context = context;
        }
       
        public async Task<YearEvent> AddAsync(int eventId, int calendarId, DateTime gregorianDate)
        {
            var newYearEvent = new YearEvent
            { 
                EventId = eventId,
                CalendarId = calendarId,
                GregorianDate = gregorianDate,
               } ;
            await _context.YearEvents.AddAsync(newYearEvent);
            await _context.SaveChangesAsync();
            return newYearEvent;
        }

        public async Task DeleteAsync(int id)
        {
            var yearEvent = await GetByIdAsync(id);
            _context.YearEvents.Remove(yearEvent);
            await _context.SaveChangesAsync();
            
        }

        public async Task<List<YearEvent>> GetAllAsync()
        {
            return await _context.YearEvents.ToListAsync();
        }

        public async Task<YearEvent> GetByIdAsync(int id)
        {
            return await _context.YearEvents.FindAsync(id);
        }

        //public async Task<int> GetByDetailsAsync(string name,string adress)
        //{
        //    var orderList = await GetAllAsync();
        //    return orderList.Find(u => u.Name == name && u.Adress == adress).Id;
        //}
        //public async Task<int> GetByTzAsync(string tz)
        //{
        //    var parentsList = await GetAllAsync();
        //    return parentsList.Find(u => u.Tz == tz).Id;
       
        //}
        public async Task<YearEvent> UpdateAsync(YearEvent yearEvent)
        {
            var updatedYearEvent = _context.YearEvents.Update(yearEvent);
            await _context.SaveChangesAsync();
            return updatedYearEvent.Entity;
        }

        
    }
}
