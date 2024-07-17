using AutoMapper;
using Repository.Entities;
using CalendarApp.Repositories.Entities;
using CalendarApp.Repositories.Interfaces;
using CalendarApp.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using CalendarApp.Common.DTOs;
using Azure.Core;
using System.Linq;
using System;

namespace CalendarApp.Services.Services
{
    public class SiteUserService : ISiteUserService
    {
        private readonly ISiteUserRepository _siteUser;
        private readonly IMapper _mapper;
        private readonly IUserService _user;
        private readonly ICalendarService _calendar;
        private readonly ICalendarUserRepository _calendarUser;

        public SiteUserService(ISiteUserRepository siteUser, IUserService user, ICalendarService calendar, ICalendarUserRepository calendarUser, IMapper mapper)
        {
            _siteUser = siteUser;
            _user = user;
            _calendar = calendar;
            _calendarUser = calendarUser;
            _mapper = mapper;
        }

        public async Task<SiteUserDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<SiteUserDTO>(await _siteUser.GetByIdAsync(id));
        }
        public async Task<SiteUserDTO> GetOrderIdAsync(int id)
        {
            return _mapper.Map<SiteUserDTO>(await _siteUser.GetByIdAsync(id));
        }
        public async Task<IEnumerable<SiteUserDTO>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<SiteUserDTO>>(await _siteUser.GetAllAsync());
        }

        public async Task<SiteUserDTO> AddAsync(SiteUserDTO user)
        {

            return _mapper.Map<SiteUserDTO>(await _siteUser.AddAsync(user.FirstName, user.LastName, user.Tz, user.Password));
        }

        public async Task<SiteUserDTO> UpdateAsync(SiteUserDTO user)
        {
            return _mapper.Map<SiteUserDTO>(await _siteUser.UpdateAsync(_mapper.Map<SiteUser>(user)));
        }

        public async Task DeleteAsync(int id)
        {
            await _siteUser.DeleteAsync(id);
        }

        public async Task<SiteUserDTO> GetByTzAndPassword(int tz, string password)
        {
            SiteUserDTO siteUser = _mapper.Map<SiteUserDTO>(await _siteUser.GetByTzAndPassword(tz, password));
            if (siteUser != null){
                var calendars = await _calendar.GetCalendarsBySiteUserId(siteUser.Id);
                siteUser.Calendars = calendars.ToList();
            }
           
            return siteUser;
        }

        public async Task<SiteUserDTO> FindByTZAsync(int tz)
        {
            return _mapper.Map<SiteUserDTO>(await _siteUser.FindByTzAsync(tz));
        }

        public async Task<SiteUserDTO> Register(SiteUserDTO siteUser, UserDTO user,Boolean isAdmin,int calendarId)
        {

            SiteUserDTO existUser = await FindByTZAsync(siteUser.Tz);

            if (existUser == null)
            {
                existUser = await AddAsync(siteUser);
      
            }


            user.SiteUserId = existUser.Id;
            var newUser = await _user.AddAsync(user);
            if (!isAdmin)
            {
                await _calendarUser.AddAsync(newUser.Id, calendarId, UserType.Editor);
            }
            return existUser;
        }

        public async Task<SiteUserDTO> GetAuthorizedUser(int siteUserId)
        {
            SiteUserDTO siteUser = await GetByIdAsync((int)siteUserId);
            var calendars = await _calendar.GetCalendarsBySiteUserId(siteUser.Id);
            siteUser.Calendars = calendars.ToList();
            return siteUser;
        }
    }
}
