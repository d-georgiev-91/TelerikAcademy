namespace MessageInABottle
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class MessageInABottle
    {
        static List<KeyValuePair<char, string>> cyphers = new List<KeyValuePair<char, string>>();
        static SortedSet<string> solutions = new SortedSet<string>();
        static string secretMessage;

        static void Main()
        {
            ReadInput();

            Solve(0, new StringBuilder());

            Console.WriteLine(solutions.Count);

            foreach (var solution in solutions)
            {
                Console.WriteLine(solution);
            }
        }
  
        private static void ReadInput()
        {
            secretMessage = Console.ReadLine();
            string messageCypher = Console.ReadLine();

            char key = char.MinValue;
            StringBuilder value = new StringBuilder();

            for (int i = 0; i < messageCypher.Length; i++)
            {
                if (char.IsLetter(messageCypher[i]))
                {
                    AddToCyphers(key, value);
                    key = messageCypher[i];
                }
                else
                {
                    value.Append(messageCypher[i]);
                }
            }

            AddToCyphers(key, value);
        }
  
        static void AddToCyphers(char key, StringBuilder value)
        {
            if (key != char.MinValue)
            {
                cyphers.Add(new KeyValuePair<char, string>(key, value.ToString()));
            }

            value.Clear();
        }
        
        static void Solve(int secretMessageIndex, StringBuilder sb)
        {
            if (secretMessageIndex == secretMessage.Length)
            {
                solutions.Add(sb.ToString());
                return;    
            }

            foreach (var cypher in cyphers)
            {
                if (secretMessage.Substring(secretMessageIndex).StartsWith(cypher.Value))
                {
                    sb.Append(cypher.Key);
                    Solve(secretMessageIndex + cypher.Value.Length, sb);
                    sb.Length--;
                }
            }
        }
    }
}