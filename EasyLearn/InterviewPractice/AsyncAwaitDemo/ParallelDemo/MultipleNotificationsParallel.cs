using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitDemo.ParallelDemo
{
    public static class MultipleNotificationsParallel
    {
        public static void Run()
        {
            Console.WriteLine("---- Parallel Demo (Multiple Notifications) ----");

            // List of users to notify
            List<string> users = new List<string>
            {
                "user1@example.com",
                "user2@example.com",
                "user3@example.com",
                "user4@example.com"
            };

            // Send notifications to all users in parallel
            Parallel.ForEach(users, user =>
            {
                Console.WriteLine($"Sending notification to {user} on Thread {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(1000); // simulate sending (email/sms)
                Console.WriteLine($"Notification sent to {user}");
            });

            Console.WriteLine("------------------------------------------------\n");
        }
    }
}
