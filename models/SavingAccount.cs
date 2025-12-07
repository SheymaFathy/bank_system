using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bank_system.helper;

namespace bank_system.models
{
  public class SavingsAccount : AccountBase
    {
        private const decimal MINIMUM_BALANCE = 100m;
        private const decimal INTEREST_RATE = 0.05m; // 5%

        public override string AccountType => "Savings";

        public decimal InterestRate => INTEREST_RATE;

        // ---------------------------------------------------
        // Withdraw: respect minimum balance
        // ---------------------------------------------------
        public override bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                AccountHelper.Error("Withdrawal amount must be greater than 0");
                return false;
            }

            if (Balance - amount < MINIMUM_BALANCE)
            {
                AccountHelper.Error(
                    $"Cannot withdraw. Minimum balance of {AccountHelper.FormatMoney(MINIMUM_BALANCE)} must be maintained.");

                return false;
            }

            return base.Withdraw(amount); // normal withdraw
        }

        // ---------------------------------------------------
        // Interest calculation & apply
        // ---------------------------------------------------
        public decimal CalculateInterest(int months)
        {
            decimal years = months / 12m;
            return Balance * InterestRate * years;
        }

        public void ApplyInterest(int months)
        {
            if (months <= 0 || Balance <= 0)
            {
                AccountHelper.Error("No interest applied.");
                return;
            }

            decimal interest = CalculateInterest(months);
            IncreaseBalance(interest);

            AccountHelper.Success(
                $"Interest of {AccountHelper.FormatMoney(interest)} applied for {months} months. " +
                $"New balance: {AccountHelper.FormatMoney(Balance)}");
        }

        // ---------------------------------------------------
        // Display
        // ---------------------------------------------------
        public override void DisplayAccount()
        {
            base.DisplayAccount();

            Console.WriteLine(
                $"Interest Rate: {InterestRate:P} | Minimum Balance: {AccountHelper.FormatMoney(MINIMUM_BALANCE)}");
        }
    }
}