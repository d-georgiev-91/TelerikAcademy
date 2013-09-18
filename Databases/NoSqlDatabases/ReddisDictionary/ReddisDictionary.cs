namespace ReddisDictionary
{
    using System;
    using System.Linq;
    using System.Threading;
    using ServiceStack.Redis;

    class ReddisDictionary
    {
        private static RedisClient client;
        private static Dictionary dictionary;

        static void Main(string[] args)
        {
            using (RedisClient client = new RedisClient(connection.Default.host, connection.Default.port, connection.Default.password))
            {
                dictionary = new Dictionary(client, "ReddisDictionary");
                InitializeMenu();
            }
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
            foreach (var item in dictionary)
            {
                Console.WriteLine("{0}: {1}", item.Word, item.Translation);
            }

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey();
        }

        private static void AddWord()
        {
            Console.Write("Word: ");
            string wordRepresentation = Console.ReadLine();
            Console.Write("Translation: ");
            string translation = Console.ReadLine();

            dictionary.Add(wordRepresentation, translation);
        }

        private static void FindWordTranslation()
        {
            Console.Write("Word: ");
            string wordRepresentation = Console.ReadLine();
            if (dictionary.ContainsWord(wordRepresentation))
            {
                Console.WriteLine(dictionary[wordRepresentation]);
            }
            else
            {
                Console.WriteLine("No such word exists");
            }

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey();
        }
    }
}