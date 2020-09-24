using System;

namespace MovieLibrary
{
    class Program
    {
        static void Main ( string[] args )
        {
            //FunWithTypes();
            //FunWithVariables();

            //while loop
            //0+ iterations, pre test condition
            while (true)
            {
                //char choice = DisplayMenu();
                //if (choice == 'Q')
                //return;
                //else if (choice == 'A')
                // AddMovie();
                switch (DisplayMenu())
                {
                    case 'Q': return;

                    case 'A': AddMovie(); break;

                    case 'V': ViewMovie(); break;
                };
            };

        }
        
        static string title = "";
        static string description = "";
        static string rating = "";
        static int duration;
        static bool isClassic;

        static void AddMovie()
           
        {
            //Get title
            Console.WriteLine("Movie Title : ");
            //string title = Console.ReadLine();

            // Type inferencing
            //string title = ReadString(true);
             title = ReadString(true);  // string title = ReadString(true);

            //Get description
            Console.WriteLine("Description (optional): ");
            //string description = Console.ReadLine();
             description = ReadString(false);

            //Get Rating
            Console.WriteLine("Rating: ");
            //string rating = Console.ReadLine();
             rating = ReadString(false);

            //Get duration
            Console.WriteLine("Duration(in minmutes): ");
            //string duration = Console.ReadLine();
             duration = ReadInt32(0);

            //Get Is Classic
            Console.WriteLine("Is Classic Y/N): ");
             isClassic = ReadBoolean();
        }

        static void ViewMovie()
        {
            Console.WriteLine(title);
            Console.WriteLine(" " + description);

            Console.WriteLine(" " + rating);

            Console.WriteLine(duration);

            Console.WriteLine(rating);
                
        }
        //Arithmetic (unary)
        //+E
        //-E

        // Arithmetic Operators (binary) - type coercion
        // Addition 10 + 12
        //Subtraction 123 - 110
        // Multiplication 10 * 20
        //Division 30 / 3
        // Modulus 7 % 4 => 3 (remainder), only works with integrals

        //int division problem
        // 10 / 3 => int / int => int => 3
        // 10.0 / 3 => double / int => double 3.33
        // (double)10 / 3 => double / int

        //typecast => (T)E
        // not allowed => (string)10, (int)"Hello", (int)10.5


        //Logical Operators(boolean)
        //NOT => !E => !(expression)
        //AND => &&
        //OR => E || E => expression || expression

        //Relational operators(all primitives + few extras)
        //equality -> E == E => expression == expression
        //inequality => E != E => expression != expression
        //greater than => E > E
        //greater then or equal to E >= E
        //less than => E < E
        //less than or equal to => E <= E
        static void FunWithStrings ()
        {
            // 5 characcters in it, takes up 10 bytes
            // C++ - No NULL
            // Escape sequence begins with \ and is followed by genrally 1 character
            // \n - newline
            // \t - tab
            // \" _ " - double quote
            // \' _ ' - character literal
            // \\ - produces a slash
            // \xHH - hex equivelent

            var name = "Bob"; // Compiler warning - Bobc
            var message = "Hello \"Bob\"\nWorld";

            var filePath = "C:\\Temp\\test.pdf";    //C:\Temp\\test.pdf
            var filePath2 = @"C:\Temp\test.pdf";    // Verbatim string
        }
            
        static string ReadString ( bool required )
        {
            do
            {
                string value = Console.ReadLine();

                // if not require or empty, return
                if (!required || value != "")
                {
                    //Is it empty
                    if (value == "")
                        DisplayError("Value is required");
                }
                return value;
            } while (true);

        }

        static char DisplayMenu ()
        {
            // 1+ Statement. Post test
            // do Statement while (Expression);
            // block statement => { Statements* }
            do
            {


                Console.WriteLine("Movie Library");
                Console.WriteLine("------------------");

                Console.WriteLine("A)dd Movie");
                Console.WriteLine("V)iew Movie");
                Console.WriteLine("Q)uit");

                //Get input from the user
                string value = Console.ReadLine();

                // if (E - boolean expression) Statement;
                if (value == "Q")   // 2 equal signs => equality
                    return 'Q';
                else if (value == "A")
                    return 'A';
                else if (value == "V")
                    return 'V';

                DisplayError("Invalid Option");
            } while (true);
        }

        private static void DisplayError (string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Invalid Option");

            Console.WriteLine(message);

            Console.ResetColor();
        }
        static int ReadInt32 ( int minValue )
        {
            return ReadInt32(Int32.MinValue);
        }
        static bool ReadBoolean ()
        {
            do
            {
                // Read a string
                string value = Console.ReadLine();

                //NOt useful of how it is parsed
                //Boolean. TryParse(value, out bool result)

                // switch - replacement for if-else-if WHEN
                // Each condiotoin is against same variable
                // AND equality
                // switch (E)
                //{
                //  case*
                //  [default]
                //}
                //case          ::* case E : S*
                //default       ::* default : S*
                //if (value == "Y" || value "y")
                // return true;
                // else if (value == "N" || value == "y")
                // return false;
                //else
                // S;
                //C++ differences
                //  1. NO fall through case E; break; case E2 : S;
                //  2. Any expressino type is allowed
                //  3. Case labels must be unique and compile time constant
                //  4. Multiple statements are allowed
                //  5.

                switch (value)
                {
                    case "X": Console.WriteLine("Wrong value"); break;

                    case "Y":          //If case statement is empty (including semi-colon), then fallthrough
                    case "y": return true;

                    case "N": 
                    case "n": return false;

                    case "A":
                    {
                        //Use block statements for more than 1 statements
                        Console.WriteLine("Wrong value");
                        Console.WriteLine("Wrong value again");
                        break;
                    }

                    default: break ;  // if nothing else
                };
                   

                DisplayError("Invalid option");
            } while (true);

        }

        private static void FunWithVariables ()
        {
            //Declares hours of type int with initial value 10 (iniitializer expression)
            int hours = 10;

            int value;
            int calculatedvalue = value = 10;
        }

        //Function Defintion: declaration + implementation
        // [modifiers] T id ([parameters]) { S* }
        //Function Signiture - [return-type] name, parameter types
        static void FunWithTypes ()
        {   //Variable - memory location to read and write a value; name, value, and type
            //
            //Literal - contain a value that can be read, fixed at compilation; type and value
            //Body

            //Primitive - type implicity known by the language

            //Integral - whole numbers
            //Signed

            //sbyte - 1 byte -128 to 127
            //Short - 2 bytes +- 32k
            //Int - 4 bytes +- 2 billion - DEFAULT
            //long - 8 bytes, really big - larger size

            //Unsigned
            //byte - 1 byte - 0 to 255
            //ushort - 2 bytes - 0 to 64k
            //uint - 4 bytes - 0 to 4 billion
            //ulong - 8 bytes - 0 to really bug
            //Literals
            //10, 20, 30, => int
            //150L => Long


        }
    }
}
