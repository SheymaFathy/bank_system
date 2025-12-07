using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bank_system.helper
{
    public class AccountHelper
    {
        // -----------------------------
        // Format currency value
        // -----------------------------
        public static string FormatMoney(decimal value)
        {
            return $"{value:C}";
        }

        // -----------------------------
        // Safe parse string to decimal
        // -----------------------------
        public static decimal ToDecimal(string input)
        {
            if (decimal.TryParse(input, out decimal result))
                return result;

            throw new ArgumentException("Invalid number format.");
        }

        // -----------------------------
        // Safe parse string to int
        // -----------------------------
        public static int ToInt(string input)
        {
            if (int.TryParse(input, out int result))
                return result;

            throw new ArgumentException("Invalid number format.");
        }

        // -----------------------------
        // Print separator lines
        // -----------------------------
        public static void PrintLine(string text = "", int length = 50)
        {
            string line = new string('=', length);
            Console.WriteLine(line);

            if (!string.IsNullOrWhiteSpace(text))
                Console.WriteLine(text);

            Console.WriteLine(line);
        }

        // -----------------------------
        // Display success message
        // -----------------------------
        public static void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        // -----------------------------
        // Display error message
        // -----------------------------
        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        // -----------------------------
        // Pause to read console
        // -----------------------------
        public static void Pause()
        {
            Console.WriteLine("\nPress ENTER to continue...");
            Console.ReadLine();
        }
    }
}