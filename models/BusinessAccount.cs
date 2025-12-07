using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bank_system.models
{
     public class BusinessAccount : AccountBase
    {
        public override string AccountType => "Business";


        public override bool Withdraw(decimal amount)
        {
            // Allow normal withdraw (no overdraft, no minimum)
            return base.Withdraw(amount);
        }

        public override bool Deposit(decimal amount)
        {
            return base.Deposit(amount);
        }

        public override void DisplayAccount()
        {
            base.DisplayAccount();
            Console.WriteLine("Business account: No overdraft | No interest");
        }
    }
}