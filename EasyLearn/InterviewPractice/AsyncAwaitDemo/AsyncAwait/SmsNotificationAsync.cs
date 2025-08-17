using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitDemo.AsyncAwait
{
    public static class SmsNotificationAsync
    {
        public static async Task Run()
        {
            Console.WriteLine("---- Async/Await Demo (SMS Notification) ----");
            await SendSmsAsync();
            Console.WriteLine("---------------------------------------------\n");
        }

        private static async Task SendSmsAsync()
        {
            Console.WriteLine("Sending SMS... (async)");
            await Task.Delay(1000);       // simulate waiting for SMS API response
            Console.WriteLine("SMS sent to +91-9876543210");
        }
    }
}
