using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiddlewareDemo.Controllers
{
    [ApiController]
    [Route("notify")]
    public class NotificationController : ControllerBase
    {
        [HttpGet("email")]
        public IActionResult SendEmailNotification()
        {
            // This action simulates sending an email notification
            // The actual email sending logic would go here
            Console.WriteLine("[NotificationController] Email notification triggered.");
            return Ok("Email notification sent successfully.");
        }

        [HttpGet("blocked")]
        public IActionResult BlockedNotification()
        {
            return StatusCode(StatusCodes.Status403Forbidden, "Access to this notification is blocked.");

        }
    }
}
