namespace SuperMarketQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    class Person : IComparable
    {
        public Person(int position, string name)
        {
            this.Position = position;
            this.Name = name;
        }

        public int CompareTo(object obj)
        {
            return this.Position.CompareTo((obj as Person).Position);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public int Position { get; set; }

        public string Name { get; set; }
    }

    class SuperMarketQueue
    {
        static OrderedBag<Person> queue = new OrderedBag<Person>();
        static Dictionary<string, int> peopleInQueue = new Dictionary<string, int>();
        static StringBuilder output = new StringBuilder();

        static void Main()
        {
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                Process(command);
            }

            Console.Write(output);
        }

        private static void Process(string command)
        {
            var commandWithParameters = command.Split(' ');

            switch (commandWithParameters[0])
            {
                case "Append":
                    Append(commandWithParameters[1]);
                    break;
                case "Insert":
                    Insert(commandWithParameters[1], commandWithParameters[2]);
                    break;
                case "Find":
                    Find(commandWithParameters[1]);
                    break;
                case "Serve":
                    Serve(commandWithParameters[1]);
                    break;
                default:
                    throw new ArgumentException("Invalid command" + command);
            }
        }

        private static void Serve(string countAsString)
        {
            int count = int.Parse(countAsString);

            if (count > queue.Count)
            {
                output.AppendLine("Error");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                string currentName = queue.GetFirst().Name;
                queue.RemoveFirst();
                peopleInQueue[currentName]--;

                if (peopleInQueue[currentName] == 0)
                {
                    peopleInQueue.Remove(currentName);
                }

                if (i < count - 1)
                {
                    output.AppendFormat("{0} ", currentName);
                }
                else
                {
                    output.AppendLine(currentName);
                }
            }
        }

        private static void Append(string name)
        {
            int position = queue.Count;
            queue.Add(new Person(position, name));

            if (peopleInQueue.ContainsKey(name))
            {
                peopleInQueue[name]++;
            }
            else
            {
                peopleInQueue.Add(name, 1);
            }

            output.AppendLine("OK");
        }

        private static void Insert(string positionAsString, string name)
        {
            int position = int.Parse(positionAsString);

            if (queue.Count < position)
            {
                output.AppendLine("Error");
                return;
            }

            int queueCount = queue.Count;
            OrderedBag<Person> queueCopy = new OrderedBag<Person>();

            for (int i = 0; i < position; i++)
            {
                Person currentPerson = queue.GetFirst();
                queue.RemoveFirst();
                queueCopy.Add(currentPerson);
            }

            queueCopy.Add(new Person(position, name));

            if (peopleInQueue.ContainsKey(name))
            {
                peopleInQueue[name]++;
            }
            else
            {
                peopleInQueue.Add(name, 1);
            }

            while (queue.Count > 0)
            {
                Person currentPerson = queue.GetFirst();
                currentPerson.Position++;
                queue.RemoveFirst();
                queueCopy.Add(currentPerson);
            }

            queue = queueCopy;
            output.AppendLine("OK");
        }

        private static void Find(string name)
        {
            if (peopleInQueue.ContainsKey(name))
            {
                output.AppendLine(peopleInQueue[name].ToString());
            }
            else
            {
                output.AppendLine("0");
            }
        }
    }
}