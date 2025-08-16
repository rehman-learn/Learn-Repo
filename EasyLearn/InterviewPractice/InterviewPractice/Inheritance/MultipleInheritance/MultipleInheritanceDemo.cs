using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops_Practice.Inheritance.Multipleinheritance
{
    public interface IFirstInterface
    {
        void MethodA();
    
    }

    public interface ISecondInterface
    {
        void MethodB();
    }

    public class MultipleInheritanceDemo : IFirstInterface, ISecondInterface
    {
        public void MethodA()
        {
            Console.WriteLine("MethodA from MultipleInheritanceDemo class.");
        }

        public void MethodB()
        {
            Console.WriteLine("MethodB from MultipleInheritanceDemo class.");
        }

    }
    
}
