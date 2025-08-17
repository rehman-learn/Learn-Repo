namespace MiddlewareDemo.Middlewares
{
    public class EmailNotificationMiddleware
    {
        private readonly RequestDelegate _next;
        public EmailNotificationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            // Simulate sending an email notification
            Console.WriteLine("[Email Notification] Sending email...");
            // Call the next middleware in the pipeline

            await _next(context);
            // Log after the response is sent
            Console.WriteLine("[Email Notification] Email sent successfully.");
        }
    }
}
