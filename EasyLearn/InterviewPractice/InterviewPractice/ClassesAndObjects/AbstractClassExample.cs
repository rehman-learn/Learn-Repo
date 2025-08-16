using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops_Practice.ClassesAndObjects
{
    public abstract class AbstractClassExample
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }

        public abstract int Calculate();

        public void DisplayResult()
        {
            Console.WriteLine($"The result of the calculation is: {Calculate()}");
        }
    }

    public class  MultiplicationAbs : AbstractClassExample
    {
        public override int Calculate()
        {
            return Number1 * Number2;
        }
    }
}
