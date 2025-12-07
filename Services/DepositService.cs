using System;
using bank_system.Validation;

namespace bank_system.Services
{
    public static class DepositService
    {
        public static bool Process(AccountBase account, decimal amount)
        {
            AccountValidator.ValidateAmount(amount);

            account.IncreaseBalance(amount);

            Console.WriteLine($"💰 Deposit: {amount:C}");
            Console.WriteLine($"✔ New Balance: {account.Balance:C}");
            return true;
        }
    }
}
