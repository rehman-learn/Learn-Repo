using DependencyInjectionDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionDemo.Interfaces;

namespace DependencyInjectionDemo.Services
{
    public class EmailNotificationService : INotificationService
    {
        public void sendNotification()
        {
            Console.WriteLine("Test Email Sent to Example@gmail.com");
        }
    }
}
