using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        string userInput = Console.ReadLine();
        
        // Convert the input to an integer
        int gradePercentage = int.Parse(userInput);

        // Initialize the letter variable and sign
        string letter = "";
        string sign = "";

        // Determine the letter grade
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the sign
        if (letter != "F" && letter != "A")
        {
            int lastDigit = gradePercentage % 10; // Get the last digit
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // Print the final letter grade with sign
        Console.WriteLine($"Your letter grade is: {letter}{sign}");

        // Check if the user passed or failed
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations, you passed!");
        }
        else
        {
            Console.WriteLine("Keep trying, you can do it next time!");
        }
    }
}