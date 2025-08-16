using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    public class ReportGenerator
    {
        public void GenerateReport(string fileName, string status)
        {
            Console.WriteLine($"[Report] Report generated for '{fileName}' with status: {status}");
        }
    }
}
