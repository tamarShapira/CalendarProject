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
    public class YearEventService : IYearEventService
    {
        private readonly IYearEventRepository _yearEvent;
        private readonly IMapper _mapper;

        public YearEventService(IYearEventRepository yearEvent, IMapper mapper)
        {
            _yearEvent = yearEvent;
            _mapper = mapper;
        }

        public async Task<YearEventDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<YearEventDTO>(await _yearEvent.GetByIdAsync(id));
        }
        //public async Task<YearEventDTO> GetOrderIdAsync(int eventId ,int calendarId, DateOnly gregorianDate)
        //{
        //    return _mapper.Map<YearEventDTO>(await _yearEvent.GetByDetailsAsync(name,adress));
        //}

        public async Task<IEnumerable<YearEventDTO>> GetListAsync()
        {
            //לוגיקה עסקית
            return _mapper.Map<IEnumerable<YearEventDTO>>(await _yearEvent.GetAllAsync());
        }

        public async Task<YearEventDTO> AddAsync(YearEventDTO yearEvent)
        {
            
            return _mapper.Map<YearEventDTO>(await _yearEvent.AddAsync(yearEvent.EventId,yearEvent.CalendarId,yearEvent.GregorianDate));
        }

        public async Task<YearEventDTO> UpdateAsync(YearEventDTO yearEvent)
        {
            return _mapper.Map<YearEventDTO>(await _yearEvent.UpdateAsync(_mapper.Map<YearEvent>(yearEvent)));
        }

        public async Task DeleteAsync(int id)
        {
            await _yearEvent.DeleteAsync(id);
        }
    }
}
