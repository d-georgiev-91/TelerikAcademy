namespace StringCountWithinStringServiceLibrary
{
    using System;
    using System.Text.RegularExpressions;

    public class StringCountWithinStringService : IServiceStringCountWithinString
    {
        public int GetStringCountWithinString(string innerString, string outerString)
        {
            if (innerString == null || outerString == null)
            {
                throw new ArgumentException("The string should be non nullabel");
            }

            int apperianceCount = 0;
            var matches = Regex.Matches(outerString, innerString);
            apperianceCount = matches.Count;

            return apperianceCount;
        }
    }
}
