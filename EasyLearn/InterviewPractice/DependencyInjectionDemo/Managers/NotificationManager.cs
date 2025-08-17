using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionDemo.Interfaces;

namespace DependencyInjectionDemo.Managers
{
    public class NotificationManager
    {
        private readonly INotificationService _notificationService;
        public NotificationManager(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        public void Notify()
        {
            _notificationService.sendNotification();
        }
    }
}
