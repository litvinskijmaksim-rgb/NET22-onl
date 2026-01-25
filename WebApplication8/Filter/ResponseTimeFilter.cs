
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication8.Filters
{
    public class ResponseTimeFilter : IActionFilter
    {
        private DateTime _startTime;

        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _startTime = DateTime.Now;  
        }

        
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var endTime = DateTime.Now; 
            var duration = endTime - _startTime;  

            
            context.HttpContext.Response.Headers.Add("X-Response-Time", $"{duration.TotalMilliseconds}ms");
            context.HttpContext.Response.Headers.Add("X-Request-Start", _startTime.ToString("HH:mm:ss.fff"));
            context.HttpContext.Response.Headers.Add("X-Request-End", endTime.ToString("HH:mm:ss.fff"));
        }
    }
}