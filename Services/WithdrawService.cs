using System;
using bank_system.Validation;

namespace bank_system.Services
{
    public static class WithdrawService
    {
        public static bool Process(AccountBase account, decimal amount)
        {
            AccountValidator.ValidateAmount(amount);

            if (account.Balance < amount)
            {
                Console.WriteLine("Insufficient balance.");
                return false;
            }

            account.DecreaseBalance(amount);

            Console.WriteLine($" Withdraw: {amount:C}");
            Console.WriteLine($" New Balance: {account.Balance:C}");
            return true;
        }
    }
}
