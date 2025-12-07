using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bank_system
{
   public interface IAccount
    {
        int Id { get; set; }

        string AccountNumber { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string FullName { get; set; }

        // Read-only (Encapsulation) → الرصيد مينفعش يتعدّل من بره
        decimal Balance { get; }

        // نوع الحساب (savings, checking, business…)
        string AccountType { get; }

        // كل حساب تابع لفرع
        int BranchId { get; set; }

        // Operations
        bool Deposit(decimal amount);
        bool Withdraw(decimal amount);
        bool Transfer(IAccount toAccount, decimal amount);

        // Display Methods
        void DisplayAccount();
        string GetAccountDetail();
    }
}