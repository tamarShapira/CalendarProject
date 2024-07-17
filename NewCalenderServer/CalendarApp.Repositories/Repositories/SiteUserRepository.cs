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
    public class SiteUserRepository : ISiteUserRepository
    {
        readonly IContext _context;

        public SiteUserRepository(IContext context)
        {
            _context = context;
        }

        public async Task<SiteUser> AddAsync(string firstName, string lastName, int tz, string password)
        {
            var newSiteUser = new SiteUser
            {
                FirstName = firstName,
                LastName = lastName,
                Tz = tz,
                Password = password
            };
            await _context.SiteUsers.AddAsync(newSiteUser);
            await _context.SaveChangesAsync();
            return newSiteUser;
        }

        public async Task DeleteAsync(int id)
        {
            var siteUser = await GetByIdAsync(id);
            _context.SiteUsers.Remove(siteUser);
            await _context.SaveChangesAsync();

        }

        public async Task<SiteUser> FindByTzAsync(int tz)
        {
            return await _context.SiteUsers.FirstOrDefaultAsync(siteUser => siteUser.Tz == tz);
        }

        public async Task<List<SiteUser>> GetAllAsync()
        {
            return await _context.SiteUsers.ToListAsync();
        }

        public async Task<SiteUser> GetByTzAndPassword(int tz, string password)
        {
            return await _context.SiteUsers.FirstOrDefaultAsync(user => user.Tz == tz && user.Password == password);
        }

        public async Task<SiteUser> GetByIdAsync(int id)
        {
            return await _context.SiteUsers.FindAsync(id);
        }

        public async Task<SiteUser> UpdateAsync(SiteUser user)
        {
            var updatedUser = _context.SiteUsers.Update(user);
            await _context.SaveChangesAsync();
            return updatedUser.Entity;
        }
    }
}
