using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAndCollectionDemo.Models
{
    public class SMSNotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"SMS: {message}");
        }
    }
}
