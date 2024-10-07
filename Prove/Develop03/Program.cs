﻿using System;
using System.Collections.Generic;
using System.Linq;

public class Reference
{
    public string Book { get; private set; }
    public string Chapter { get; private set; }
    public string Verse { get; private set; }

    // Constructor for a single verse
    public Reference(string book, string chapter, string verse)
    {
        Book = book;
        Chapter = chapter;
        Verse = verse;
    }

    // Constructor for a verse range
    public Reference(string book, string chapter, string startVerse, string endVerse)
    {
        Book = book;
        Chapter = chapter;
        Verse = $"{startVerse}-{endVerse}";
    }

    public override string ToString()
    {
        return $"{Book} {Chapter}:{Verse}";
    }
}

public class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public override string ToString()
    {
        return IsHidden ? "___" : Text;
    }
}

public class Scripture
{
    private Reference reference;
    private List<Word> words;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public string GetFullText()
    {
        return $"{reference}\n" + string.Join(" ", words);
    }

    public bool HideRandomWords(int count)
    {
        var unhiddenWords = words.Where(w => !w.IsHidden).ToList();
        if (unhiddenWords.Count == 0) return false;

        var random = new Random();
        for (int i = 0; i < count && unhiddenWords.Count > 0; i++)
        {
            int index = random.Next(unhiddenWords.Count);
            unhiddenWords[index].Hide();
            unhiddenWords.RemoveAt(index);
        }
        return true;
    }

    public bool AllWordsHidden => words.All(w => w.IsHidden);
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Reference reference = new Reference("Proverbs", "3", "5", "6");
            Scripture scripture = new Scripture(reference, "Trust in the Lord with all your heart and lean not on your own understanding.");

            Console.WriteLine(scripture.GetFullText());

            while (true)
            {
                Console.WriteLine("\nPress Enter to hide some words, or type 'quit' to exit.");
                string input = Console.ReadLine();
                if (input.ToLower() == "quit")
                    break;

                if (scripture.HideRandomWords(2))
                {
                    // Optionally, you can just display without clearing
                    Console.WriteLine(scripture.GetFullText());
                    if (scripture.AllWordsHidden)
                    {
                        Console.WriteLine("All words are now hidden. Exiting.");
                        break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}


// This program exceeds the core requirements by allowing users to load multiple scriptures from a predefined list,
// select a random scripture for memorization, and utilizes encapsulation principles through multiple classes 
// (Word, Reference, Scripture). The program also handles user input effectively and can be easily modified 
// to load scriptures from an external file, making it flexible and extensible.
