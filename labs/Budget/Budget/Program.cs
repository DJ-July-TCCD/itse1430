
/* 
 * Delendrick July
 * ITSE 1430
 * Lab 01
 * 09/05/2020
 */
  using System;
using System.Globalization;

namespace Budget
{ 
    // This block of code is intended to simulate starting an account with a bank.
    // This block will simulate retrieveing necessary account information.
    class Program
    {
        public static void Main()
        {
            /*This code prompts the user to enter a name or identifier for the account. 
             Any input that doesn't follow the set rules will prompt an error message and return the user to the program.*/
            string AccountName = "";
            Console.WriteLine("Account Name: ");
            AccountName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(AccountName))
            {
                Console.WriteLine("Invalid. Please enter a valid name for the account.");
                Console.WriteLine("Account Name: ");
                Console.ReadLine();
            }

            /*This code prompts the user enter an ID number for the account. Any invalid input prompts an error message and
             returns the user to the program.*/
            string AccountID;
            Console.WriteLine("Enter a unique Account ID Number: ");
            AccountID = Console.ReadLine();
            if(String.IsNullOrEmpty(AccountID))
            {
                Console.WriteLine(" Invalid. Please enter a valid Acount ID Number.");
                Console.WriteLine(" Account ID: ");
                Console.ReadLine();
            }

            /*This code prompts the user to enter the account balence. Any invalid input or an input that is 
             less than or equal to zero will prompt an error message and return the user to the program.*/
            Console.WriteLine("Enter the account balence: ");
            string input = Console.ReadLine();
            decimal AccountBalence;
            if (Decimal.TryParse(input, out AccountBalence));
            if(AccountBalence == 0 && AccountBalence < 0 )
            {
                Console.WriteLine("Invalid Account Balence. Please try again.");
                Console.WriteLine("Enter Account Balence: ");
                Console.ReadLine();
            }

            //The code below displays the menu of the bank account and is
            //intended to allow the user to choose their desired option.
            Console.WriteLine("\t\tAccount Menu\t\t");
            Console.WriteLine("".PadLeft(60, '-'));
            Console.WriteLine("D)eposit Funds");
            Console.WriteLine("W)ithdraw Funds");
            Console.WriteLine("Q)uit");
            var choice = Console.ReadLine();

            if(choice != "D" && choice != "d" && choice != "W" && choice != "w"  && choice != "Q" && choice != "q")
            {
                Console.WriteLine("That input is invalid. Please try again.");
                Console.WriteLine("\t\tAccount Menu\t\t");
                Console.WriteLine("".PadLeft(60, '-'));
                Console.WriteLine("D)eposit Funds");
                Console.WriteLine("W)ithdraw Funds");
                Console.WriteLine("Q)uit");
                Console.ReadLine();
            }

            //The code below excecutes when the user chooses the option to terminate the account program.
            if(choice == "Q" || choice == "q")
            {
                Console.WriteLine("This choice will end the program. Are you sure? Y/N");
                string EndChoice = Console.ReadLine();

                if (EndChoice == "Y" || choice == "y")
                {
                    Console.WriteLine("Program ending. Goodbye.");

                } 
                else if (EndChoice == "N" || EndChoice == "n")
                {
                    Console.WriteLine("Please choose a valid menu option.");
                    Console.WriteLine("\t\tAccount Menu\t\t");
                    Console.WriteLine("".PadLeft(60, '-'));
                    Console.WriteLine("D)eposit Funds");
                    Console.WriteLine("W)ithdraw Funds");
                    Console.WriteLine("Q)uit");
                    return;
                } else
                    Console.WriteLine("Invalid input. Try again.");
                return;
            }

            //The code below exceutes when the user chooses the option to add income to the account.
            if (choice == "D" || choice == "d")
            {
                Console.WriteLine("Enter your deposit amount. (Greater than zero please.");
                string amount = Console.ReadLine();
                decimal AccountDeposit;
                if (Decimal.TryParse(amount, out AccountDeposit)) ;
                if (AccountDeposit == 0)
                {
                    Console.WriteLine("Please enter a vaild amount.");
                    Console.ReadLine();
                }
                Console.WriteLine("Please provide a description for this deposit.");
                string description = Console.ReadLine();
                if (description == "")
                {
                    Console.WriteLine("Please enter a valid description for the deposit.");
                    Console.ReadLine();
                }
                Console.WriteLine("Optional: ");
                string category = Console.ReadLine();

                decimal UpdateBalence = AccountDeposit + AccountBalence;
                Console.WriteLine("Account has been updated. Your current balence is $" + UpdateBalence);
                object Culture = null;
                if (DateTime.TryParse("09/25/2020", out var value)) ;
                Console.WriteLine(value);
            }

            if(choice == "W" || choice == "w")
            {
                Console.WriteLine("How much would you like to Withdraw?");
                string expense = Console.ReadLine();
                decimal AccountWithdrawl;
                if (Decimal.TryParse(expense, out AccountWithdrawl)) ;
                if (AccountWithdrawl > AccountBalence)
                {
                    Console.WriteLine("Insuffcient Funds. Please choose a smaller amount.");
                    Console.WriteLine("Please enter a withdrawl amount.");
                    Console.ReadLine();
                    return;
                }

                if (AccountWithdrawl < AccountBalence)
                {
                    Console.WriteLine("Please provide a description for this expense.");
                    string ExpenseDescription = Console.ReadLine();

                    if (ExpenseDescription == "")
                    {
                        Console.WriteLine("Please provide a description for the expense.");
                        return;
                    }
                    Console.WriteLine("Optional:");
                    Console.ReadLine();

                    decimal NewBalence = AccountBalence - AccountWithdrawl;
                    Console.WriteLine("Account has been updated. Your new balence is $" + NewBalence);
                    if (DateTime.TryParse("09/25/2020", out var value)) ;
                    Console.WriteLine(value);
                }
            }
           
        }
    }
}
