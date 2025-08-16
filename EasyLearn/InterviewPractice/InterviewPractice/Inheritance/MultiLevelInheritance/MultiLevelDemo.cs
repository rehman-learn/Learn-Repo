using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops_Practice.Inheritance.MultiLevelInheritance
{
    public class MultiLevelDemo
    {
        public void DisplayMessage()
        {
            Console.WriteLine("Hello from the base class of MultiLevel Inheritance.");
        }
    }

    public class DerivedClassML : MultiLevelDemo
    {
        public void DisplayDerivedMessage()
        {
            Console.WriteLine("Hello from the first derived class of MultiLevel Inheritance.");
        }
    }
    public class FurtherDerivedClassML : DerivedClassML
    {
        public void DisplayFurtherDerivedMessage()
        {
            Console.WriteLine("Hello from the second derived class of MultiLevel Inheritance.");
        }
    }
}
