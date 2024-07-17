using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using CalendarApp.Repositories.Entities;
using CalendarApp.Common.DTOs;
using CalendarApp.Services.Interfaces;
using CalendarApp.Services.Services;
using CalendarApp.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CalendarApp.WebAPI.Helpers;


namespace CalendarApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarUserController : ControllerBase
    {
        readonly ICalendarUserService _calendarUser;
      

        public CalendarUserController(ICalendarUserService calendarUser)
        {
            _calendarUser = calendarUser;
        }

        // GET: api/<RolesController>
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<CalendarUserDTO>> Get()
        {
            //var user = (SiteUserDTO)HttpContext.Items["User"];
            //return await _calendarUser.GetListAsync(user.Id);
            throw new NotImplementedException();
        }
        [HttpGet("{id}")]
        public async Task<CalendarUserDTO> GetById(int id)
        {
            return await _calendarUser.GetByIdAsync(id);
        }
        [HttpDelete]
        public async Task Delete(int id)
        {
            await _calendarUser.DeleteAsync(id);
        }
        
        [HttpPost]
        public async Task Post([FromBody] CalendarUserModel calendarUser)
        {
          //  Debug.WriteLine(order.IdParent);

            await _calendarUser.AddAsync(new CalendarUserDTO
            {  
                //FamilyId = calendarUser.FamilyId,
                //LevelId = calendarUser.LevelId,
                //UserId = calendarUser.UserId,
                //UserType = calendarUser.UserType,
            });
        }
        [HttpPut]
        public async Task Put(CalendarUserDTO calendarUser)
        {
            await _calendarUser.UpdateAsync(calendarUser);
        }
        //[HttpGet("name/{name},adress/{adress}")]
        //public async Task<YearEventDTO> GetByDetails(string name,string adress)
        //{


        //    return await _order.GetOrderIdAsync(name,adress);
        //}
    }
}
