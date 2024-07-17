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
    public class UserRepository : IUserRepository
    {
        readonly IContext _context;

        public UserRepository(IContext context)
        {
            _context = context;
        }

        public async Task<User> AddAsync(int tz, string firstName, string lastName, string phoneNumber, string email, int? spouseId, int? fatherId, int? motherId, DateTime bornDate, int? siteUserId)
        {
            var newUser = new User
            { 
                TZ=tz,
                FirstName=firstName,
                LastName=lastName,
                PhoneNumber=phoneNumber,
                Email=email,
                SpouseId=spouseId,
                FatherId=fatherId,
                MotherId=motherId,
                BornDate=bornDate,
                SiteUserId=siteUserId
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            
        }

        public async Task<User> UpdateAsync(User user)
        {
            var updatedUser = _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return updatedUser.Entity;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetByTzAsync(int tz)
        {
            return await _context.Users.FirstAsync(t => t.TZ == tz);
        }


        public async Task<List<User>> getBySiteUserAsync(int siteUserId)
        {
            return await _context.Users.Where(d => d.SiteUserId == siteUserId).ToListAsync();
        }

        public Task<User> AddAsync(int tz, string firstName, string lastName, string phoneNumbar, string email, int spouseId, int fatherId, int motherId, DateTime bornDate, int siteUserId)
        {
            throw new NotImplementedException();
        }
    }
}
