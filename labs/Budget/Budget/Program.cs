
/* 
 * Delendrick July
 * ITSE 1430
 * Lab 01
 * 09/05/2020
 */
  using System;

namespace Budget
{ 
    // This block of code is intended to simulate starting an account with a bank.
    // This block will simulate retrieveing necessary account information.
    class Program
    {
        static void Main()
        {
            // Name the account
            string AccountName = "";
            Console.WriteLine("Account Name: ");
            AccountName = Console.ReadLine();

            // Enter the Account ID number
            string AccountNumber;
            Console.WriteLine("Enter 6-digit Account ID Number: ");
            AccountNumber = Console.ReadLine();


            // Enter the starting Account Balence
            Console.WriteLine("Enter the account balence: ");
            string input = Console.ReadLine();

            decimal AccountBalence;
            if (Decimal.TryParse(input, out AccountBalence));
        }

        static void AccountMenu ()
        {
            Console.WriteLine("\t\tAccount Menu\t\t");
            Console.WriteLine("".PadLeft(60, '-'));
            Console.WriteLine("D)eposit Funds");
            Console.WriteLine("W)ithdraw Funds");
            Console.WriteLine("Q)uit");

            string choice = Console.ReadLine();

            if (String.Compare(choice, "D", true) == 'q')
                return 'D';
        }

        static void ExitMenu()
        {
            
        }

        static void ErrorMessage(string messsage)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("This choice is not valid. Try again.");
        }
    }
}