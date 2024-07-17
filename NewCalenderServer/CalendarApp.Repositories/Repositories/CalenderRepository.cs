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
    public class CalendarRepository : ICalendarRepository
    {
        readonly IContext _context;

        public CalendarRepository(IContext context)
        {
            _context = context;
        }
       
        public async Task<Calendar> AddAsync(int directorId,string groupName)
        {
            var newCalendar = new Calendar
            { 
                DirectorId = directorId,    
                GroupName = groupName
                } ;
            await _context.Calendars.AddAsync(newCalendar);
            await _context.SaveChangesAsync();
            return newCalendar;
        }

        public async Task DeleteAsync(int id)
        {
            var calendar = await GetByIdAsync(id);
            _context.Calendars.Remove(calendar);
            await _context.SaveChangesAsync();
            
        }

        public async Task<List<Calendar>> GetAllAsync()
        {
            return await _context.Calendars.ToListAsync();
        }

        public async Task<Calendar> GetByIdAsync(int id)
        {
            return await _context.Calendars.FindAsync(id);
        }

        public async Task<Calendar> UpdateAsync(Calendar calendar)
        {
            var updatedCalendar = _context.Calendars.Update(calendar);
            await _context.SaveChangesAsync();
            return updatedCalendar.Entity;
        }

        public async Task<List<Calendar>> GetCalendarsBySiteUserId(int siteUserId)
        {
            return await _context.CalendarUsers
                .Where(calendarUser => calendarUser.User.SiteUserId == siteUserId)
                .Select(calendarUser => calendarUser.Calendar)
                .ToListAsync();
        }

        public async Task<List<CalendarUser>> GetUsersByCalendar( int calendarId)
        {
            var users = await _context.CalendarUsers
                .Include(calendarUser => calendarUser.User)
                .Where(calendarUser =>  calendarUser.CalendarId == calendarId)
                .ToListAsync();

            return users;
        }
     
    }
}
