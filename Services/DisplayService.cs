using System;

namespace bank_system.Services
{
    public static class DisplayService
    {
        public static void Print(AccountBase account)
        {
            Console.WriteLine(
                $"[{account.AccountType}] {account.FullName}\n" +
                $"Acc: {account.AccountNumber}\n" +
                $"Balance: {account.Balance:C}\n" +
                $"Branch: {account.BranchId}"
            );
        }

        public static string Details(AccountBase account)
        {
            return
                $"Account Type: {account.AccountType}\n" +
                $"Full Name: {account.FullName}\n" +
                $"Account Number: {account.AccountNumber}\n" +
                $"Email: {account.Email}\n" +
                $"Phone: {account.PhoneNumber}\n" +
                $"Balance: {account.Balance:C}\n" +
                $"Branch ID: {account.BranchId}";
        }
    }
}
