using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    public class Logger
    {
        public void LogToConsole(string fileName, string status)
        {
            Console.WriteLine($"[Logger] File '{fileName}' processed with status: {status}");
        }
    }
}
