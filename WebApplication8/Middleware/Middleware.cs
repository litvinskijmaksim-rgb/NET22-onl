
namespace WebApplication8.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
           
            _logger.LogInformation($"Начало запроса: {context.Request.Path}");

            
            await _next(context);

            
            _logger.LogInformation($"Запрос завершен: {context.Request.Path}, Статус: {context.Response.StatusCode}");
        }
    }
}