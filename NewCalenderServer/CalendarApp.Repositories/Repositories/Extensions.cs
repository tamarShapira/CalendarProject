using Microsoft.Extensions.DependencyInjection;
using CalendarApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Repositories.Repositories
{
    public static class Extensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IYearEventRepository, YearEventRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<ISiteUserRepository, SiteUserRepository>();
            services.AddScoped<ICalendarRepository, CalendarRepository>();
            services.AddScoped<ICalendarUserRepository, CalendarUserRepository>();
            services.AddScoped<ICalendarYearRepository, CalendarYearRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
            
            return services;
        }
    }
}
