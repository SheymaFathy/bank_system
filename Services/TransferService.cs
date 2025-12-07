using System;

namespace bank_system.Services
{
    public static class TransferService
    {
        public static bool Process(AccountBase fromAccount, IAccount toAccount, decimal amount)
        {
            if (toAccount == null)
            {
                Console.WriteLine("Destination account cannot be null.");
                return false;
            }

            if (ReferenceEquals(fromAccount, toAccount))
            {
                Console.WriteLine("Cannot transfer to the same account.");
                return false;
            }

            if (!WithdrawService.Process(fromAccount, amount))
                return false;

            DepositService.Process((AccountBase)toAccount, amount);

            Console.WriteLine($"Transfer {amount:C} to {toAccount.AccountNumber} successful.");
            return true;
        }
    }
}
