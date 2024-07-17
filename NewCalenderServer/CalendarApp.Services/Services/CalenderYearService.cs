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
    public class CalendarYearService : ICalendarYearService
    {
        private readonly ICalendarYearRepository _calendarYear;
        private readonly IMapper _mapper;

        public CalendarYearService(ICalendarYearRepository calendarYear, IMapper mapper)
        {
            _calendarYear = calendarYear;
            _mapper = mapper;
        }

        public async Task<CalendarYearDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<CalendarYearDTO>(await _calendarYear.GetByIdAsync(id));
        }
       
        public async Task<CalendarYearDTO> GetOrderIdAsync(int id)
        {
            return _mapper.Map<CalendarYearDTO>(await _calendarYear.GetByIdAsync(id));
        }
        public async Task<IEnumerable<CalendarYearDTO>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<CalendarYearDTO>>(await _calendarYear.GetAllAsync());
        }

        public async Task<CalendarYearDTO> AddAsync(CalendarYearDTO calendarYear)
        {
            
            return _mapper.Map<CalendarYearDTO>(await _calendarYear.AddAsync(calendarYear.CalendarId,calendarYear.Year));
        }

        public async Task<CalendarYearDTO> UpdateAsync(CalendarYearDTO calendarYear)
        {
            return _mapper.Map<CalendarYearDTO>(await _calendarYear.UpdateAsync(_mapper.Map<CalendarYear>(calendarYear)));
        }

        public async Task DeleteAsync(int id)
        {
            await _calendarYear.DeleteAsync(id);
        }
    }
}
