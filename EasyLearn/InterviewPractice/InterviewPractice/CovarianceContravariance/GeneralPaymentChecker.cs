using Oops_Practice.CovarianceContravariance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops_Practice.CovarianceContravariance
{
    //Contravaiant Interface
    interface IPaymentChecker<in T>
    {
        void Check(T payment);
    }

    // General checker for ANY kind of payment
    class GeneralPaymentChecker : IPaymentChecker<Payment>
    {
        public void Check(Payment payment)
        {
            Console.WriteLine($"Checking payment of {payment.Amount}");
        }
    }
}
