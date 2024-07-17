using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
namespace CalendarApp.WebAPI.Middlewares
{
    public class TrackMiddleware
    {
        private readonly RequestDelegate _next;

        public TrackMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var guid = Guid.NewGuid().ToString();//יצירת מפתח לבקשה
            context.Items.Add("ReqSeq", guid);//שמירת המפתח בקונטקסט של הבקשה
            Console.WriteLine($"Request {guid} started the pipeline");//רישום ללוג
            await _next(context);//גלגול הבקשה לפונקציה הבאה
            Console.WriteLine($"Request {guid} ended the pipeline");//רישום ללוג בסיום הבקשה
        }
    }

    public static class TrackMiddlewareExtension
    {
        public static IApplicationBuilder UseTrack(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<TrackMiddleware>();

            return builder;
        }
    }
}
