using System;
using bank_system.Services;
using bank_system.Validation;

namespace bank_system
{
    public class AccountBase : IAccount
    {
        private int _id;
        private string? _email;
        private string? _accountNumber;
        private string? _fullName;
        protected decimal _balance;

        private string? _phoneNumber;
        private int _branchId;

        // ===========================
        // Properties
        // ===========================

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string AccountNumber
        {
            get => _accountNumber!;
            set
            {
                AccountValidator.ValidateAccountNumber(value);
                _accountNumber = value;
            }
        }

        public string Email
        {
            get => _email!;
            set
            {
                AccountValidator.ValidateEmail(value);
                _email = value;
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber!;
            set
            {
                AccountValidator.ValidatePhone(value);
                _phoneNumber = value;
            }
        }

        public string FullName
        {
            get => _fullName!;
            set
            {
                AccountValidator.ValidateName(value);
                _fullName = value;
            }
        }

        // Read-only
        public decimal Balance => _balance;

        public virtual string AccountType => "Base";

        public int BranchId
        {
            get => _branchId;
            set
            {
                AccountValidator.ValidateBranch(value);
                _branchId = value;
            }
        }

        // ===========================
        // Balance Helpers (Encapsulation)
        // ===========================

        public void IncreaseBalance(decimal amount) => _balance += amount;

        public void DecreaseBalance(decimal amount) => _balance -= amount;

        // ===========================
        // Operations
        // ===========================

        public virtual bool Deposit(decimal amount)
        {
            return DepositService.Process(this, amount);
        }

        public virtual bool Withdraw(decimal amount)
        {
            return WithdrawService.Process(this, amount);
        }

        public bool Transfer(IAccount toAccount, decimal amount)
        {
            return TransferService.Process(this, toAccount, amount);
        }

        public virtual void DisplayAccount()
        {
            DisplayService.Print(this);
        }

        public virtual string GetAccountDetail()
        {
            return DisplayService.Details(this);
        }
    }
}
