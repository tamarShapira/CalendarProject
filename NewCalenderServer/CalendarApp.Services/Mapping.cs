using AutoMapper;
using Repository.Entities;
using CalendarApp.Repositories.Entities;
using CalendarApp.Common.DTOs;
using System;

namespace CalendarApp.Services
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<YearEvent, YearEventDTO>().ReverseMap();   
            CreateMap<UserType, UserTypeDTO>().ReverseMap();
            CreateMap<SiteUser, SiteUserDTO>().ReverseMap();
            CreateMap<Event, EventDTO>().ReverseMap();
            CreateMap<Calendar, CalendarDTO>().ReverseMap();
            CreateMap<CalendarUser, CalendarUserDTO>().ReverseMap();
            CreateMap<CalendarYear, CalendarYearDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
