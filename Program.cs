using bank_system.Services;
using bank_system.helper;

public class Program
{
    public static void Main()
    {
        var bank = new BankService();

        while (true)
        {
            Console.Clear();
            PrintMenu();

            Console.Write("\nSelect option: ");
            string choice = Console.ReadLine()!;

            Console.Clear();
          // menu 
            switch (choice)
            {
                case "1": bank.CreateAccount(); break;
                case "2": bank.DisplayAccounts(); break;
                case "3": bank.Deposit(); break;
                case "4": bank.Withdraw(); break;
                case "5": bank.Transfer(); break;
                case "0":
                    AccountHelper.Success("Goodbye!");
                    return;

                default: AccountHelper.Error("Invalid selection"); break;
            }

            AccountHelper.Pause();
        }
    }

    public static void PrintMenu()
    {
        AccountHelper.PrintLine("BANK SYSTEM MENU");
        Console.WriteLine("1) Create Account");
        Console.WriteLine("2) Display Accounts");
        Console.WriteLine("3) Deposit");
        Console.WriteLine("4) Withdraw");
        Console.WriteLine("5) Transfer");
        Console.WriteLine("0) Exit");
    }
}
