namespace DoublePasswords
{
    using System;

    class DoublePasswords
    {
        static void Main()
        {
            string passwordTemplate = Console.ReadLine();
            
            int unknowDigitsCount = GetUnknownDigitsCount(passwordTemplate);

            ulong possiblePasswordsCount = 1ul << unknowDigitsCount;

            Console.WriteLine(possiblePasswordsCount);
        }
  
        private static int GetUnknownDigitsCount(string passwordTemplate)
        {
            int unknowDigitsCount = 0;

            for (int i = 0; i < passwordTemplate.Length; i++)
            {
                if (passwordTemplate[i] == '*')
                {
                    unknowDigitsCount++;
                }
            }
            return unknowDigitsCount;
        }
    }
}