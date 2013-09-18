using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ExtractDateFromText
{
    class ExtractDateFromText
    {
        static void Main()
        {
            Console.Write("Enter some text with or without dates: ");
            string text = Console.ReadLine();
            MatchCollection dates = Regex.Matches(text, @"\b\d{2}.\d{2}.\d{4}\b");
            DateTime date;
            foreach (var item in dates)
            {
                if (DateTime.TryParse(item.ToString(), out date))
                {
                    Console.WriteLine(date.ToString(CultureInfo.GetCultureInfo("en-CA")));
                }
            }
        }
    }
}
