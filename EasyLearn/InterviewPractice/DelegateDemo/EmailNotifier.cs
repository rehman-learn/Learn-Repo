using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    public class EmailNotifier
    {
        public void SendEmail(string fileName, string status)
        {
            Console.WriteLine($"[Email] Sent email: File '{fileName}' -> {status}");
        }
    }
}
