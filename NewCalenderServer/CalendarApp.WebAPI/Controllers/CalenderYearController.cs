using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository.Entities;
using CalendarApp.Repositories.Entities;
using CalendarApp.Common.DTOs;
using CalendarApp.Services.Interfaces;
using CalendarApp.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace CalendarApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarYearController : ControllerBase
    {
        readonly ICalendarYearService _calendarYear;
      

        public CalendarYearController(ICalendarYearService calendarYear)
        {
            _calendarYear = calendarYear;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public async Task<IEnumerable<CalendarYearDTO>> Get()
        {
            return await _calendarYear.GetListAsync();
        }
        [HttpGet("{id}")]
        public async Task<CalendarYearDTO> GetById(int id)
        {
            return await _calendarYear.GetByIdAsync(id);
        }
        [HttpDelete]
        public async Task Delete(int id)
        {
            await _calendarYear.DeleteAsync(id);
        }
        
        [HttpPost]
        public async Task Post([FromBody] CalendarYearModel calendarYear)
        {
          //  Debug.WriteLine(order.IdParent);

            await _calendarYear.AddAsync(new CalendarYearDTO
            {  
                 CalendarId=calendarYear.CalendarId,
                 Year=calendarYear.Year,
            });
        }
        [HttpPut]
        public async Task Put(CalendarYearDTO calendarYear)
        {
            await _calendarYear.UpdateAsync(calendarYear);
        }
        //[HttpGet("name/{name},adress/{adress}")]
        //public async Task<YearEventDTO> GetByDetails(string name,string adress)
        //{


        //    return await _order.GetOrderIdAsync(name,adress);
        //}
    }
}
