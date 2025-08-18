using System.Diagnostics;

namespace TaskManagementDemo.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            await _next(context);
            stopwatch.Stop();
            Console.WriteLine($"Request {context.Request.Method} {context.Request.Path} took {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
