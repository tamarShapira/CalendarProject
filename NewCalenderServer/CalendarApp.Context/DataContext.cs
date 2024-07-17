using Microsoft.EntityFrameworkCore;

using System;
using System.Data;
using System.Security;
using CalendarApp.Repositories;
using CalendarApp.Repositories.Interfaces;
using Repository.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CalendarApp.Context
{
    public class DataContext : DbContext, IContext
    {
        public DbSet<YearEvent> YearEvents { get; set; }

        public DbSet<SiteUser> SiteUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<CalendarYear> CalendarYears { get; set; }
        public DbSet<CalendarUser> CalendarUsers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
           "Server=(localdb)\\mssqllocaldb;Database=Calender2_DB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dateOnlyConverter = new ValueConverter<DateOnly, DateTime>(
    v => new DateTime(v.Year, v.Month, v.Day),
    v => new DateOnly(v.Year, v.Month, v.Day)
);
            //set relationships
            modelBuilder.Entity<Calendar>()
                .HasMany(c => c.CalendarUsers)
                .WithOne(cu => cu.Calendar)
                .HasForeignKey(cu => cu.CalendarId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.CalendarUsers)
                .WithOne(cu => cu.User)
                .HasForeignKey(cu => cu.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CalendarUser>()
                .HasOne(cu => cu.User)
                .WithMany(u => u.CalendarUsers)
                .HasForeignKey(cu => cu.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
               .HasOne(d => d.SiteUser)
               .WithMany(u => u.Users)
               .HasForeignKey(d => d.SiteUserId);

            modelBuilder.Entity<User>()
                .HasOne(d => d.Spouse)
                .WithOne()
                .HasForeignKey<User>(d => d.SpouseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(d => d.Father)
                .WithOne()
                .HasForeignKey<User>(d => d.FatherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(d => d.Mother)
                .WithOne()
                .HasForeignKey<User>(d => d.MotherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<YearEvent>()
                .HasOne(ye => ye.Event)
                .WithMany()
                .HasForeignKey(ye => ye.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Event>()
          .Property(e => e.GregorianDate)
          .HasConversion(dateOnlyConverter);

            //convert enums to string
            modelBuilder.Entity<CalendarUser>().Property(u => u.UserType).HasConversion<string>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
