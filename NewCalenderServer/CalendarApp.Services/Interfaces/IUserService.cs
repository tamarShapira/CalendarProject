using CalendarApp.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CalendarApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetListAsync();

        Task<UserDTO> GetByIdAsync(int id);

        Task<UserDTO> GetByTzAsync(int tz);

        Task<UserDTO> AddAsync(UserDTO user);

        Task<UserDTO> UpdateAsync(UserDTO user);

        Task DeleteAsync(int id);
        Task<IEnumerable<UserDTO>> getBySiteUserAsync(int siteUserId);
    }
}