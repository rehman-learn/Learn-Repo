using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    public delegate void FileProcessedHandler(string fileName, string status); //This is the delegate definition and any method stored in this delegate must match this signature 

    public class FileProcessor
    {
        // 2. Create delegate variable
        public FileProcessedHandler OnFileProcessed; // this is a multicast delegate that can hold references to multiple methods and any method that matches the signature of this delegate can be assigned to it

        public void ProcessFile(string fileName)
        {
            Console.WriteLine($"Processing file: {fileName}");
            System.Threading.Thread.Sleep(1000); // Simulate work
            string status = "Success";

            // 3. Invoke delegate if it has subscribers
            OnFileProcessed?.Invoke(fileName, status);
        }
    }
}
/*

1. Eg: public delegate void FileProcessedHandler(string fileName, string status); 
   This is the delegate definition and any method stored in this delegate must match this signature 

2. public FileProcessedHandler OnFileProcessed;
   This is a multicast delegate that can hold references to multiple methods and any method that matches the signature of this delegate can be assigned to it

*/