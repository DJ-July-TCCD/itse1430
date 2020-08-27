/*
 * Delendrick July
 * ITSE 1430
 * Lab 1
 */
using System;

namespace HelloWorld
{
    // Pascal Casing - Capitalize on word boundaries including first word
    // Camel Casing - Capitalize on word boundaries except first word
    class Program
    {
        // Fucntion Declaration - declaration to compiler that a faunction exists with a given signiture
        // Function Signiture - function name and the parameter types ( somtimes will include retunr types)
        // Functoin defintion - declaration + implementation
        static void Main(string[] args) // 1 parameter
        {
            // A single line comment
            // Another line of comment
            
            // Display given string to output
            Console.WriteLine("Hello World!"); // printf, cout

            // Variable Declaration
            // T- type, ID-identifier, T id;
            //int hours;
            //hours = 10; // Assignment operator: id = E

            // Identifier Rules
            // 1. Unique withine scope
            // 2. Must start with underscore or letter
            // 3. Consist of letter, digits, and underscores
            // Always Camel Case local variables, noun
            // Preferred: T id = E;
            int hours = 10;

            // int pay = 0;
            //pay = hours * 9;
            int totalPay = hours * 9;

            // Function overload - multiple functions with same name but different parameters
            // atof, atoi
            Console.WriteLine(totalPay);
        }
    }
}
