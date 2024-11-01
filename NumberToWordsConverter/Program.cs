using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user to enter a number between 0 and 999999
        Console.WriteLine("Enter a number (0-999999):");

        // Attempt to parse the user input as a long integer
        if (long.TryParse(Console.ReadLine(), out long number))
        {
            // Convert the number to words and print the result
            Console.WriteLine(NumberToWords(number));
        }
        else
        {
            // If input is invalid, display an error message
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    // Method to convert a number to its word representation
    static string NumberToWords(long number)
    {
        // Special case: if the number is 0, return "zero"
        if (number == 0)
            return "zero";

        // If the number is negative, handle it as "minus" + absolute value
        if (number < 0)
            return "minus " + NumberToWords(Math.Abs(number));

        string words = ""; // Initialize an empty string to store the words

        // Check for thousands (e.g., 1149 -> "one thousand")
        if ((number / 1000) > 0)
        {
            // Recursive call for the thousands part and append "thousand"
            words += NumberToWords(number / 1000) + " thousand ";
            // Remove the thousands part from the number
            number %= 1000;
        }

        // Check for hundreds (e.g., 149 -> "one hundred")
        if ((number / 100) > 0)
        {
            // Recursive call for the hundreds part and append "hundred"
            words += NumberToWords(number / 100) + " hundred ";
            // Remove the hundreds part from the number
            number %= 100;
        }

        // Process the tens and units
        if (number > 0)
        {
            // Add "and" if there were previous parts (thousands or hundreds)
            if (words != "")
                words += "and ";

            // Define arrays for units and tens mapping
            var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
                                   "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            // If number is less than 20, fetch from unitsMap directly
            if (number < 20)
                words += unitsMap[number];
            else
            {
                // For numbers 20 and above, fetch from tensMap and append units if any
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += "-" + unitsMap[number % 10]; // Append hyphen for numbers like "forty-two"
            }
        }

        // Return the final result after trimming any extra spaces
        return words.Trim();
    }
}

