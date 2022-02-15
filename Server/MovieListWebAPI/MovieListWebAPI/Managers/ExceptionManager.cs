using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MovieListWebAPI.Exceptions;

namespace MovieListWebAPI.Managers
{
    public class ExceptionManager
    {
        private readonly RequestDelegate _next;

        public ExceptionManager(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (NotFoundException e)
            {
                await context.Response.WriteAsync(e.Message);
            }
            catch (UserInputException e)
            {
                await context.Response.WriteAsync(e.Message);
            }
            catch 
            {
                await context.Response.WriteAsync("Oops, something went wrong :(");
            }
        }
    }
}
