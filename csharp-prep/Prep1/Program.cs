
using System;

class Program
{
    static void Main(string[] args)
    {
        // first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Display full name
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}