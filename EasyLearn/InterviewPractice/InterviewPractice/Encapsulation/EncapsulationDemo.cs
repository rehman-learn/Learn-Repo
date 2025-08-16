using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops_Practice.Encapsulation
{
    public class EncapsulationDemo
    {
        private double balance;

        // Public method to set/modify balance
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
            }
        }

        // Public method to read balance (controlled access)
        public double GetBalance()
        {
            return balance;
        }
    }
}
