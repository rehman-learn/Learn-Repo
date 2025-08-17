using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitDemo.TaskDemo
{
    public static class EmailNotificationTask
    {
        public static async Task Run()
        {
            Console.WriteLine("---- Task Demo (Email Notification) ----");

            Task sendEmailTask = Task.Run(() =>
            {
                Thread.Sleep(1000);  // simulate sending email
                Console.WriteLine("Email sent to customer@example.com");
            });

            await sendEmailTask; // wait for task to finish

            Console.WriteLine("----------------------------------------\n");
        }
    }
}
