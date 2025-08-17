using DependencyInjectionDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionDemo.Services
{
    public class SmsNotificationService : INotificationService
    {
        public void sendNotification()
        {
            Console.WriteLine($"SMS sent to +91-98546 32541   ");
        }
    }
   
}
