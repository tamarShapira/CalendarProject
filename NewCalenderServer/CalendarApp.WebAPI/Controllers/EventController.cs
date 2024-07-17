using Microsoft.AspNetCore.Mvc;
using CalendarApp.Repositories.Entities;
using CalendarApp.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using CalendarApp.Common.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Globalization;
using System.Linq;

namespace CalendarApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        readonly IEventService _eevent;


        public EventController(IEventService eevent)
        {
            _eevent = eevent;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public async Task<IEnumerable<EventDTO>> Get()
        {
            return await _eevent.GetListAsync();
        }
        [HttpGet("{id}")]
        public async Task<EventDTO> GetById(int id)
        {
            return await _eevent.GetByIdAsync(id);
        }
        [HttpDelete]
        public async Task Delete(int id)
        {
            await _eevent.DeleteAsync(id);
        }

        [HttpPost]
        public async Task Post([FromBody] EventModel eevent)
        {
            char[] formattedDate = eevent.GregorianDate.ToCharArray();

            for (int i = 0; i < formattedDate.Length; i++)
            {
                if (!char.IsDigit(formattedDate[i]))
                {
                    formattedDate[i] = '/'; // Replace non-digit characters with a space
                }
            }
            string tempGregorianDate = new string(formattedDate);

            // Parse the date string to a DateTime object with the specified format
            string[] dateParts = tempGregorianDate.Split('/');

            int day = int.Parse(dateParts[2]);
            int month = int.Parse(dateParts[5]);
            int year = int.Parse(dateParts[8]);
            DateOnly newGregorianDate = new DateOnly(year, month, day);
            // Create a DateOnly object using the DateTime object
            //       DateOnly dateOnly = DateOnly.FromDateTime(dateTime);

            string newEventYear = new string(eevent.EventYear.Where(c => char.IsDigit(c)).ToArray());

            await _eevent.AddAsync(new EventDTO
            {
                CalendarId = eevent.CalendarId,
                EventOwnerName = eevent.EventOwnerName,
                GregorianDate = newGregorianDate,
                EventType = eevent.EventType,
                EventYear = eevent.EventYear,
                OneTimeEvent = eevent.OneTimeEvent,
                UserId = eevent.UserId,
            });
        }
        [HttpPut]
        public async Task Put(EventDTO eevent)
        {
            await _eevent.UpdateAsync(eevent);
        }
        //  [HttpGet("name/{name},adress/{adress}")]
        //public async Task<YearEventDTO> GetByDetails(string name,string adress)
        //{


        //    return await _eevent.GetOrderIdAsync(name,adress);
        //}
    }
}
