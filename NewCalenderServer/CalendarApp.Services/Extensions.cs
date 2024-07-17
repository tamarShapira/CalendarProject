using Microsoft.Extensions.DependencyInjection;
using CalendarApp.Repositories.Repositories;
using CalendarApp.Services.Interfaces;
using CalendarApp.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarApp.WebAPI.Services;

namespace CalendarApp.Services
{
    public static class Extensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddRepositories();

            services.AddScoped<IYearEventService, YearEventService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<ISiteUserService, SiteUserService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEventService,EventService>();
            services.AddScoped<ICalendarService, CalendarService>();
            services.AddScoped<ICalendarYearService, CalendarYearService>();
            services.AddScoped<ICalendarUserService, CalendarUserService>();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
