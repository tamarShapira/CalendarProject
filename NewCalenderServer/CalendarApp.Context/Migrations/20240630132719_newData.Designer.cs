﻿// <auto-generated />
using System;
using CalendarApp.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CalendarApp.Context.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240630132719_newData")]
    partial class newData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Repository.Entities.Calendar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SiteUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.HasIndex("SiteUserId");

                    b.ToTable("Calendars");
                });

            modelBuilder.Entity("Repository.Entities.CalendarUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CalendarId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.HasIndex("UserId");

                    b.ToTable("CalendarUsers");
                });

            modelBuilder.Entity("Repository.Entities.CalendarYear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CalendarId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.ToTable("CalendarYears");
                });

            modelBuilder.Entity("Repository.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CalendarId")
                        .HasColumnType("int");

                    b.Property<string>("EventType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HebrewDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OneTimeEvent")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.HasIndex("UserId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Repository.Entities.Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LevelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("Repository.Entities.SiteUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tz")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SiteUsers");
                });

            modelBuilder.Entity("Repository.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BornDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FatherId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MotherId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SiteUserId")
                        .HasColumnType("int");

                    b.Property<int?>("SpouseId")
                        .HasColumnType("int");

                    b.Property<int>("TZ")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FatherId")
                        .IsUnique()
                        .HasFilter("[FatherId] IS NOT NULL");

                    b.HasIndex("MotherId")
                        .IsUnique()
                        .HasFilter("[MotherId] IS NOT NULL");

                    b.HasIndex("SiteUserId");

                    b.HasIndex("SpouseId")
                        .IsUnique()
                        .HasFilter("[SpouseId] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Repository.Entities.YearEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CalendarId")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<DateTime>("GregorianDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.HasIndex("EventId");

                    b.ToTable("YearEvents");
                });

            modelBuilder.Entity("Repository.Entities.Calendar", b =>
                {
                    b.HasOne("Repository.Entities.User", "Director")
                        .WithMany()
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repository.Entities.SiteUser", null)
                        .WithMany("Calendars")
                        .HasForeignKey("SiteUserId");

                    b.Navigation("Director");
                });

            modelBuilder.Entity("Repository.Entities.CalendarUser", b =>
                {
                    b.HasOne("Repository.Entities.Calendar", "Calendar")
                        .WithMany("CalendarUsers")
                        .HasForeignKey("CalendarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repository.Entities.User", "User")
                        .WithMany("CalendarUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Calendar");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Repository.Entities.CalendarYear", b =>
                {
                    b.HasOne("Repository.Entities.Calendar", "Calendar")
                        .WithMany("CalendarYears")
                        .HasForeignKey("CalendarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calendar");
                });

            modelBuilder.Entity("Repository.Entities.Event", b =>
                {
                    b.HasOne("Repository.Entities.Calendar", "Calendar")
                        .WithMany("Events")
                        .HasForeignKey("CalendarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repository.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Calendar");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Repository.Entities.User", b =>
                {
                    b.HasOne("Repository.Entities.User", "Father")
                        .WithOne()
                        .HasForeignKey("Repository.Entities.User", "FatherId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Repository.Entities.User", "Mother")
                        .WithOne()
                        .HasForeignKey("Repository.Entities.User", "MotherId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Repository.Entities.SiteUser", "SiteUser")
                        .WithMany("Users")
                        .HasForeignKey("SiteUserId");

                    b.HasOne("Repository.Entities.User", "Spouse")
                        .WithOne()
                        .HasForeignKey("Repository.Entities.User", "SpouseId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Father");

                    b.Navigation("Mother");

                    b.Navigation("SiteUser");

                    b.Navigation("Spouse");
                });

            modelBuilder.Entity("Repository.Entities.YearEvent", b =>
                {
                    b.HasOne("Repository.Entities.Calendar", "Calendar")
                        .WithMany()
                        .HasForeignKey("CalendarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repository.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Calendar");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Repository.Entities.Calendar", b =>
                {
                    b.Navigation("CalendarUsers");

                    b.Navigation("CalendarYears");

                    b.Navigation("Events");
                });

            modelBuilder.Entity("Repository.Entities.SiteUser", b =>
                {
                    b.Navigation("Calendars");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Repository.Entities.User", b =>
                {
                    b.Navigation("CalendarUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
