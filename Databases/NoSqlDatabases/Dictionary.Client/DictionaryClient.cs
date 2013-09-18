using System;
using System.Linq;
using System.Text;
using System.Threading;
using Dictionary.Data;

namespace Dictionary.Client
{
    static class DictionaryClient
    {
        static void Main()
        {
            InitializeMenu();
        }
  
        private static void InitializeMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add new word");
                Console.WriteLine("2. Find word");
                Console.WriteLine("3. List all word");
                Console.WriteLine("4. Exit");
                int menuOption = 0;

                try
                {
                    menuOption = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter a number");
                }

                Console.Clear();

                switch (menuOption)
                {
                    case 1:
                        AddWord();
                        break;
                    case 2:
                        FindWordTranslation();
                        break;
                    case 3:
                        ListAllWords();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }

        private static void ListAllWords()
        {
            var dictionaryDb = MongoDbProvider.db;
            var words = dictionaryDb.LoadData<Word>().ToList();
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < words.Count; i++)
            {
                string outputFormat;
                if (i != words.Count - 1)
                {
                    outputFormat = "{0}: {1}\n";
                }
                else
                {
                    outputFormat = "{0}: {1}";
                }

                output.AppendFormat(outputFormat, words[i].Reperesentation, words[i].Translation);
            }

            Console.WriteLine(output);
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey();
        }

        private static void AddWord()
        {
            Console.Write("Word: ");
            string wordRepresentation = Console.ReadLine();
            Console.Write("Translation: ");
            string translation = Console.ReadLine();

            Word word = new Word(wordRepresentation, translation);
            var dictionaryDb = MongoDbProvider.db;
            dictionaryDb.SaveData<Word>(word);
        }

        private static void FindWordTranslation()
        {
            Console.Write("Word: ");
            string wordRepresentation = Console.ReadLine();
            var dictionaryDb = MongoDbProvider.db;
            var word = dictionaryDb.LoadData<Word>()
                        .Where(w => w.Reperesentation == wordRepresentation)
                        .FirstOrDefault();
            if (word == null)
            {
                Console.WriteLine("No such word exists");
            }
            else
            {
                Console.WriteLine(word.Translation);
            }

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey();
        }
    }
}