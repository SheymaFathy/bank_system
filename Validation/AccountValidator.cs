using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bank_system.Validation
{
    public class AccountValidator
    {// -----------------------------
        // Validate Full Name
        // -----------------------------
        public static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Full name cannot be empty.");

            if (name.Length < 3)
                throw new ArgumentException("Full name must be at least 3 characters.");
        }

        // -----------------------------
        // Validate Email
        // -----------------------------
        public static void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty.");

            if (!email.Contains("@") || !email.Contains("."))
                throw new ArgumentException("Invalid email format.");
        }

        // -----------------------------
        // Validate Phone Number
        // -----------------------------
        public static void ValidatePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                throw new ArgumentException("Phone number cannot be empty.");

            if (phone.Length < 10)
                throw new ArgumentException("Phone number must be at least 10 digits.");

            if (!phone.All(char.IsDigit))
                throw new ArgumentException("Phone number must contain digits only.");
        }

        // -----------------------------
        // Validate Numeric Amount
        // -----------------------------
        public static void ValidateAmount(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");
        }

        // -----------------------------
        // Validate Account Number
        // -----------------------------
        public static void ValidateAccountNumber(string accountNumber)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
                throw new ArgumentException("Account number cannot be empty.");

            if (accountNumber.Length < 4)
                throw new ArgumentException("Account number must be at least 4 digits.");
        }

        // -----------------------------
        // Validate Branch Id
        // -----------------------------
        public static void ValidateBranch(int branchId)
        {
            if (branchId <= 0)
                throw new ArgumentException("Invalid branch ID.");
        }
    }
}