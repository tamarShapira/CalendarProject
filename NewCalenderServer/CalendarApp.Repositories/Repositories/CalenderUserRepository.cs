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
    public class CalendarUserRepository : ICalendarUserRepository
    {
        readonly IContext _context;

        public CalendarUserRepository(IContext context)
        {
            _context = context;
        }
       
        public async Task<CalendarUser> AddAsync(int userId, int calendarId ,UserType userType)
        {

            var newCalendarUser = new CalendarUser
            { 
                UserId = userId, 
                CalendarId = calendarId,
                UserType = userType
                //LevelId = levelId,
                //FamilyId = familyId
            } ;
            await _context.CalendarUsers.AddAsync(newCalendarUser);
            await _context.SaveChangesAsync();
            return newCalendarUser;
        }

        public async Task DeleteAsync(int id)
        {
            var calendarUser = await GetByIdAsync(id);
            _context.CalendarUsers.Remove(calendarUser);
            await _context.SaveChangesAsync();
            
        }

        public async Task<List<CalendarUser>> GetAllAsync()
        {
            return await _context.CalendarUsers.ToListAsync();
        }

        public async Task<CalendarUser> GetByIdAsync(int id)
        {
            return await _context.CalendarUsers.FindAsync(id);
        }

      
        //public async Task<int> GetByTzAsync(string tz)
        //{
        //    var parentsList = await GetAllAsync();
        //    return parentsList.Find(u => u.Tz == tz).Id;
       
        //}
        public async Task<CalendarUser> UpdateAsync(CalendarUser calendarUser)
        {
            var updatedCalendarUser = _context.CalendarUsers.Update(calendarUser);
            await _context.SaveChangesAsync();
            return updatedCalendarUser.Entity;
        }

        
    }
}
