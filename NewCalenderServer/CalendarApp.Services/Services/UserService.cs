using AutoMapper;
using Repository.Entities;
using CalendarApp.Repositories.Entities;
using CalendarApp.Repositories.Interfaces;
using CalendarApp.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CalendarApp.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _user;
        private readonly IMapper _mapper;

        public UserService(IUserRepository user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<UserDTO>(await _user.GetByIdAsync(id));
        }

        public async Task<UserDTO> GetByTzAsync(int tz)
        {
            return _mapper.Map<UserDTO>(await _user.GetByTzAsync(tz));
        }


        public async Task<IEnumerable<UserDTO>> getBySiteUserAsync(int userId)
        {
            return _mapper.Map<IEnumerable<UserDTO>>(await _user.getBySiteUserAsync(userId));
        }

        public async Task<UserDTO> GetOrderIdAsync(int id)
        {
            return _mapper.Map<UserDTO>(await _user.GetByIdAsync(id));
        }
        public async Task<IEnumerable<UserDTO>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<UserDTO>>(await _user.GetAllAsync());
        }

        public async Task<UserDTO> AddAsync(UserDTO user)
        {
            User response = await _user.AddAsync(
                user.TZ,
                user.FirstName,
                user.LastName,
                user.PhoneNumber,
                user.Email,
                user.SpouseId,
                user.FatherId,
                user.MotherId,
                user.BornDate,
                user.SiteUserId
            );

            return _mapper.Map<UserDTO>(response);
        }

        public async Task<UserDTO> UpdateAsync(UserDTO user)
        {
            return _mapper.Map<UserDTO>(await _user.UpdateAsync(_mapper.Map<User>(user)));
        }

        public async Task DeleteAsync(int id)
        {
            await _user.DeleteAsync(id);
        }

    }
}
