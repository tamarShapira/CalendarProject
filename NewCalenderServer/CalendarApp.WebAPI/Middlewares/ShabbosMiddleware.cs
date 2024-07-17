using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CalendarApp.WebAPI.Middlewares
{
    public class ShabbosMiddleware
    {
    //    private readonly RequestDelegate _next;

    //    public ShabbosMiddleware(RequestDelegate next)
    //    {
    //        _next = next;
    //    }

    //    public async Task InvokeAsync(HttpContext context)
    //    {

    //        if (DateTime.Now.DayOfWeek != DayOfWeek.Saturday)
    //            await _next(context);//גלגול הבקשה לפונקציה הבאה
    //        else context.Response.StatusCode = StatusCodes.Status400BadRequest;

    //    }
    //}

    //public static class ShabbosMiddlewareExtension
    //{
    //    public static IApplicationBuilder UseShabbos(this IApplicationBuilder builder)
    //    {
    //        builder.UseMiddleware<ShabbosMiddleware>();

    //        return builder;
    //    }
    }
}
