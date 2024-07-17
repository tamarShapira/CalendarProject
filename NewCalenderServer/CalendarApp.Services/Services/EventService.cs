using AutoMapper;
using Repository.Entities;
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
    public class EventService : IEventService
    {
        private readonly IEventRepository _event;
        private readonly IMapper _mapper;

        public EventService(IEventRepository eevent, IMapper mapper)
        {
            _event = eevent;
            _mapper = mapper;
        }

        public async Task<EventDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<EventDTO>(await _event.GetByIdAsync(id));
        }
       
        public async Task<EventDTO> GetOrderIdAsync(int id)
        {
            return _mapper.Map<EventDTO>(await _event.GetByIdAsync(id));
        }
        public async Task<IEnumerable<EventDTO>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<EventDTO>>(await _event.GetAllAsync());
        }

        public async Task<EventDTO> AddAsync(EventDTO eevent)
        {
            
            return _mapper.Map<EventDTO>(await _event.AddAsync(eevent.CalendarId,eevent.EventOwnerName, eevent.GregorianDate ,eevent.EventType,eevent.UserId,eevent.EventYear,eevent.OneTimeEvent));
        }

        public async Task<EventDTO> UpdateAsync(EventDTO eevent)
        {
            return _mapper.Map<EventDTO>(await _event.UpdateAsync(_mapper.Map<Event>(eevent)));
        }

        public async Task DeleteAsync(int id)
        {
            await _event.DeleteAsync(id);
        }
    }
}
