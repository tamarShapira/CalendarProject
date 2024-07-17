using AutoMapper;
using Repository.Entities;
using CalendarApp.Repositories.Entities;
using CalendarApp.Repositories.Interfaces;
using CalendarApp.Repositories.Repositories;
using CalendarApp.Common.DTOs;
using CalendarApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;

namespace CalendarApp.Services.Services
{
    public class CalendarUserService : ICalendarUserService
    {
        private readonly ICalendarUserRepository _calendarUser;
        private readonly IUserService _user;
        private readonly IMapper _mapper;

        public CalendarUserService(ICalendarUserRepository calendarUser, IUserService user, IMapper mapper)
        {
            _calendarUser = calendarUser;
            _mapper = mapper;
            _user = user;
        }

        public async Task<CalendarUserDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<CalendarUserDTO>(await _calendarUser.GetByIdAsync(id));
        }

        public async Task<IEnumerable<CalendarUserDTO>> GetListAsync(int userId)
        {
            List<UserDTO> users = (List<UserDTO>)await _user.getBySiteUserAsync(userId);
            //TODO: get calendars by userid
            return _mapper.Map<IEnumerable<CalendarUserDTO>>(await _calendarUser.GetAllAsync());
        }

        public async Task<CalendarUserDTO> AddAsync(CalendarUserDTO calendarUser)
        {
            
            return _mapper.Map<CalendarUserDTO>(await _calendarUser.AddAsync(calendarUser.UserId, calendarUser.CalendarId, _mapper.Map<UserType>(calendarUser.UserType)));
        }

        public async Task<CalendarUserDTO> UpdateAsync(CalendarUserDTO calendarUser)
        {
            return _mapper.Map<CalendarUserDTO>(await _calendarUser.UpdateAsync(_mapper.Map<CalendarUser>(calendarUser)));
        }

        public async Task DeleteAsync(int id)
        {
            await _calendarUser.DeleteAsync(id);
        }
    }
}
