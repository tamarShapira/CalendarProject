using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using CalendarApp.Repositories.Entities;
using CalendarApp.Common.DTOs;
using CalendarApp.Services.Interfaces;
using CalendarApp.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;
using Repository.Entities;


namespace CalendarApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        readonly ICalendarService _calendar;
      

        public CalendarController(ICalendarService calendar)
        {
            _calendar = calendar;
        }

        // GET: api/<RolesController>
        //[HttpGet]
        //public async Task<IEnumerable<CalendarDTO>> Get()
        //{
        //    return await _calendar.GetListAsync();
        //}
        [HttpGet("{id}")]
        public async Task<CalendarDTO> GetById(int id)
        {
            return await _calendar.GetByIdAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<CalendarDTO>> GetCalendarsBySiteUserId()
        {
            int siteUserId = (int)HttpContext.Items["siteUserId"];
            return await _calendar.GetCalendarsBySiteUserId(siteUserId);
        }

        [HttpGet("users")]
        public async Task<ActionResult<UserModel>> GetCalendarUsers(int calendarId)
        {
            IEnumerable<CalendarUserDTO> calendarUsers =  await _calendar.GetUsersByCalendar( calendarId);

            var userModels = new List<UserModel>();
            foreach (var calendarUser in calendarUsers)
            {
                userModels.Add(new UserModel(calendarUser));
            }
            return Ok(userModels);
        }
        
        [HttpDelete]
        public async Task Delete(int id)
        {
            await _calendar.DeleteAsync(id);
        }

        [HttpPost]
        public async Task Post([FromBody] CalendarModel calendar)
        {
            //  Debug.WriteLine(order.IdParent);

            await _calendar.AddAsync(new CalendarDTO
            {
                DirectorId = calendar.DirectorId,
                GroupName = calendar.GroupName,
            });
        }
        [HttpPut]
        public async Task Put(CalendarDTO calendar)
        {
            await _calendar.UpdateAsync(calendar);
        }
    }
}
