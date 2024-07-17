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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserService _user;


        public UserController(IUserService user)
        {
            _user = user;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public async Task<IEnumerable<UserDTO>> Get()
        {
            return await _user.GetListAsync();
        }

        [HttpGet]
        public async Task<UserDTO> GetByTz(int tz)
        {
            return await _user.GetByTzAsync(tz);
        }
        [HttpDelete]
        public async Task Delete(int id)
        {
            await _user.DeleteAsync(id);
        }

       
        [HttpPut]
        public async Task<UserDTO> Put(UserDTO user)
        {
            return await _user.UpdateAsync(user);
        }
    }
}
