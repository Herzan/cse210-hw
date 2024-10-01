using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Scripture scripture = new Scripture(new Reference("Proverbs 3:5-6"),
                "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways acknowledge Him, and He will make your paths straight.");

            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.Display());
                Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");
                string input = Console.ReadLine();

                if (input?.ToLower() == "quit")
                {
                    break;
                }

                scripture.HideRandomWords();
                if (scripture.AllWordsHidden())
                {
                    Console.Clear();
                    Console.WriteLine("All words are now hidden.");
                    break;
                }
            }
        }
    }

    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = text.Split(' ').Select(word => new Word(word)).ToList();
        }

        public string Display()
        {
            return $"{_reference.Display()}: " + string.Join(" ", _words.Select(w => w.IsHidden ? "____" : w.Text));
        }

        public void HideRandomWords()
        {
            Random rand = new Random();
            int index = rand.Next(_words.Count);
            _words[index].Hide();
        }

        public bool AllWordsHidden()
        {
            return _words.All(w => w.IsHidden);
        }
    }

    public class Reference
    {
        private string _book;
        private int _chapter;
        private List<int> _verses;

        public Reference(string reference)
        {
            var parts = reference.Split(new[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
            _book = parts[0];
            _chapter = int.Parse(parts[1]);
            _verses = parts.Length > 2 ? parts[2].Split('-').Select(int.Parse).ToList() : new List<int> { int.Parse(parts[2]) };
        }

        public string Display()
        {
            return $"{_book} {_chapter}:{string.Join("-", _verses)}";
        }
    }

    public class Word
    {
        public string Text { get; }
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
    }
}
