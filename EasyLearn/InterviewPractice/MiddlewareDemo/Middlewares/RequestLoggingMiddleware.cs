namespace MiddlewareDemo.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            // Log the request details
            Console.WriteLine($"[Log] Incoming Request : {context.Request.Path}");

            await _next(context); // Call the next middleware in the pipeline

            Console.WriteLine($"[Log] Outgoing Response :{context.Response.StatusCode}");
        }
    }
}
