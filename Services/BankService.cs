using System;
using System.Collections.Generic;
using bank_system.models;
using bank_system.helper;

namespace bank_system.Services
{
    public class BankService
    {
        private readonly List<AccountBase> _accounts = new();

        // Create account
        public void CreateAccount()
        {
            AccountHelper.PrintLine("CREATE ACCOUNT");

            Console.WriteLine("Select account type:");
            Console.WriteLine("1) Checking");
            Console.WriteLine("2) Savings");
            Console.WriteLine("3) Business");
            Console.Write("> ");

            string? choice = Console.ReadLine();

            AccountBase account = choice switch
            {
                "1" => new CheckingAccount(),
                "2" => new SavingsAccount(),
                "3" => new BusinessAccount(),
                _ => throw new Exception("Invalid selection")
            };

            Console.Write("Enter full name: ");
            account.FullName = Console.ReadLine()!;

            Console.Write("Enter email: ");
            account.Email = Console.ReadLine()!;

            Console.Write("Enter phone: ");
            account.PhoneNumber = Console.ReadLine()!;

            Console.Write("Enter branch id: ");
            account.BranchId = int.Parse(Console.ReadLine()!);

            account.AccountNumber = DateTime.Now.Ticks.ToString();
            account.Deposit(0); // init balance

            _accounts.Add(account);

            AccountHelper.Success("\n✔ Account created successfully!");
            AccountHelper.PrintLine($"Account Number: {account.AccountNumber}");
        }


        // Display All Accounts
        public void DisplayAccounts()
        {
            AccountHelper.PrintLine("ACCOUNTS LIST");

            if (_accounts.Count == 0)
            {
                AccountHelper.Error("No accounts found");
                return;
            }

            foreach (var acc in _accounts)
            {
                acc.DisplayAccount();
                Console.WriteLine("----------------------------------");
            }
        }

        // Deposit
        public void Deposit()
        {
            AccountHelper.PrintLine("DEPOSIT");

            var acc = FindAccount();
            if (acc == null) return;

            Console.Write("Enter amount: ");
            decimal amount = decimal.Parse(Console.ReadLine()!);

            acc.Deposit(amount);
        }

        // Withdraw
        public void Withdraw()
        {
            AccountHelper.PrintLine("WITHDRAW");

            var acc = FindAccount();
            if (acc == null) return;

            Console.Write("Enter amount: ");
            decimal amount = decimal.Parse(Console.ReadLine()!);

            acc.Withdraw(amount);
        }

        // Transfer
        public void Transfer()
        {
            AccountHelper.PrintLine("TRANSFER");

            Console.WriteLine("From Account:");
            var from = FindAccount();
            if (from == null) return;

            Console.WriteLine("To Account:");
            var to = FindAccount();
            if (to == null) return;

            Console.Write("Enter amount: ");
            decimal amount = decimal.Parse(Console.ReadLine()!);

            from.Transfer(to, amount);
        }

        // Helper to find account
        private AccountBase? FindAccount()
        {
            Console.Write("Enter account number: ");
            string accNo = Console.ReadLine()!;

            var acc = _accounts.Find(a => a.AccountNumber == accNo);

            if (acc == null)
            {
                AccountHelper.Error("Account not found!");
            }

            return acc;
        }
    }
}
