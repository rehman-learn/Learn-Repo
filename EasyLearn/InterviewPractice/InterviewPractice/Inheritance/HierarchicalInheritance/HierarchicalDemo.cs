using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops_Practice.Inheritance.HeirarchicalInheritance
{
    public class HierarchicalDemo
    {
        public void DisplayMessage()
        {
            Console.WriteLine("Hello from the base class of Hierarchical Inheritance.");
        }
    }

    public class DerivedClassH1 : HierarchicalDemo
    {
        public void DisplayDerivedMessage()
        {
            Console.WriteLine("Hello from the first derived class of Hierarchical Inheritance.");
        }
    }

    public class DerivedClassH2 : HierarchicalDemo
    {
        public void DisplayDerivedMessage()
        {
            Console.WriteLine("Hello from the second derived class of Hierarchical Inheritance.");
        }
    }
}
