using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops_Practice.Inheritance.SingleInheritance
{
    public class SingleInheritanceDemo
    {
        public void DisplayMessage()
        {
            Console.WriteLine("Hello from the base class.");
        }
    }

    public class DerivedClassSI : SingleInheritanceDemo
    {
        public void DisplayDerivedMessage()
        {
            Console.WriteLine("Hello from the derived class.");
        }
    }
}
