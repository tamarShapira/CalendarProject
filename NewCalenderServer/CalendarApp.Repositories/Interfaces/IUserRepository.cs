using Repository.Entities;
using CalendarApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();

        Task<User> GetByIdAsync(int id);

        Task<User> GetByTzAsync(int tz);

        Task<User> AddAsync(int tz, string firstName, string lastName, string phoneNumbar, string email, int spouseId, int fatherId, int motherId, DateTime bornDate, int siteUserId);

        Task<User> UpdateAsync(User user);
        
        Task DeleteAsync(int id);
        Task<List<User>> getBySiteUserAsync(int siteUserId);
        Task<User> AddAsync(int tz, string firstName, string lastName, string phoneNumber, string email, int? spouseId, int? fatherId, int? motherId, DateTime bornDate, int? siteUserId);
    }
}

