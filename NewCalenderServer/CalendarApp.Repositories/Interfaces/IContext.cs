using CalendarApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace CalendarApp.Repositories.Interfaces
{
	public interface IContext
	{

		DbSet<YearEvent> YearEvents { get; set; }
		DbSet<SiteUser> SiteUsers { get; set; }
		DbSet<User> Users { get; set; }
		DbSet<Event> Events { get; set; }
		DbSet<Calendar> Calendars { get; set; }
		DbSet<CalendarUser> CalendarUsers { get; set; }
		DbSet<CalendarYear> CalendarYears { get; set; }
		
		int SaveChanges();
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
	}
}
