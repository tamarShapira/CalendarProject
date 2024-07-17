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
    public class CalendarYearRepository : ICalendarYearRepository
    {
        readonly IContext _context;

        public CalendarYearRepository(IContext context)
        {
            _context = context;
        }
       
        public async Task<CalendarYear> AddAsync(int calendarId,int year)
        {
            var newCalendarYear = new CalendarYear
            { 
                CalendarId = calendarId,
                Year = year,
                } ;
            await _context.CalendarYears.AddAsync(newCalendarYear);
            await _context.SaveChangesAsync();
            return newCalendarYear;
        }

        public async Task DeleteAsync(int id)
        {
            var payment = await GetByIdAsync(id);
            _context.CalendarYears.Remove(payment);
            await _context.SaveChangesAsync();
            
        }

        public async Task<List<CalendarYear>> GetAllAsync()
        {
            return await _context.CalendarYears.ToListAsync();
        }

        public async Task<CalendarYear> GetByIdAsync(int id)
        {
            return await _context.CalendarYears.FindAsync(id);
        }

      
        //public async Task<int> GetByTzAsync(string tz)
        //{
        //    var parentsList = await GetAllAsync();
        //    return parentsList.Find(u => u.Tz == tz).Id;
       
        //}
        public async Task<CalendarYear> UpdateAsync(CalendarYear calendarYear)
        {
            var updatedCalendarYear = _context.CalendarYears.Update(calendarYear);
            await _context.SaveChangesAsync();
            return updatedCalendarYear.Entity;
        }

        
    }
}
