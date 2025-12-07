using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bank_system.models
{
    public class CheckingAccount : AccountBase
    {
        private const decimal OVERDRAFT_LIMIT = 1000m;
        private decimal _overdraftUsed;

        public override string AccountType => "Checking";

        public decimal OverdraftLimit => OVERDRAFT_LIMIT;
        public decimal OverdraftUsed => _overdraftUsed;
        public decimal AvailableOverdraft => OverdraftLimit - OverdraftUsed;

        // --------------------------------------------
        // Withdraw override: use overdraft if needed
        // --------------------------------------------
        public override bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal must be greater than 0");
                return false;
            }

            // Total available = balance + overdraft remaining
            decimal available = Balance + AvailableOverdraft;

            if (available < amount)
            {
                Console.WriteLine($"Insufficient balance and overdraft. Available: {available:C}");
                return false;
            }

            if (Balance >= amount)
            {
                // Normal withdraw
                DecreaseBalance(amount);
            }
            else
            {
                // Part from balance + overdraft needed
                decimal overdraftNeeded = amount - Balance;

                _overdraftUsed += overdraftNeeded;
                _balance = 0;

                Console.WriteLine($" Using overdraft: {overdraftNeeded:C}");
            }

            Console.WriteLine($"Withdraw {amount:C} successful");
            Console.WriteLine($"Balance: {Balance:C}, Overdraft Used: {_overdraftUsed:C}");
            return true;
        }

        // --------------------------------------------
        // Deposit: repayment overdraft first
        // --------------------------------------------
        public override bool Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit must be greater than 0");
                return false;
            }

            // First: repay overdraft
            if (_overdraftUsed > 0)
            {
                if (amount >= _overdraftUsed)
                {
                    decimal repay = _overdraftUsed;
                    amount -= repay;
                    _overdraftUsed = 0;

                    Console.WriteLine($"Overdraft repaid: {repay:C}");
                }
                else
                {
                    _overdraftUsed -= amount;
                    Console.WriteLine($" Partial overdraft repayment: {amount:C}");
                    return true;
                }
            }

            // Remaining goes to balance
            IncreaseBalance(amount);
            Console.WriteLine($"Deposit: {amount:C}");
            Console.WriteLine($"Balance: {Balance:C}");

            return true;
        }

        // --------------------------------------------
        // Display
        // --------------------------------------------
        public override void DisplayAccount()
        {
            base.DisplayAccount();
            Console.WriteLine($"Overdraft Limit: {OverdraftLimit:C} | Used: {_overdraftUsed:C}");
        }
    }
}