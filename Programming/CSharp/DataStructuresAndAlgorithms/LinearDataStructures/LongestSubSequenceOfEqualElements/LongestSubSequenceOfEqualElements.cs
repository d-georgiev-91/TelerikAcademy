/**
* 4. Write a method that finds the longest subsequence of equal numbers in given List<int> 
* and returns the result as new List<int>. Write a program to test whether the method 
* works correctly.
*/

namespace LongestSubSequenceOfEqualElements
{
    using System;
    using System.Collections.Generic;
    //using System.Linq;

    public static class LongestSubSequenceOfEqualElements
    {
        public static void Main()
        {
            List<int> sequence = new List<int>(new int[] { 1, 5, 3, 4, 4, 4, 5, 2, 3 });
            List<int> longestSubSequenceOfEqualElements = GetLongestSubSequenceOfEqualElements(sequence);

            var output = string.Join(", ", longestSubSequenceOfEqualElements);
            Console.WriteLine(output);
        }

        /// <summary>
        /// Return the longest subsequence of equal int number of such excsist.
        /// </summary>
        /// <param name="sequence">Sequence to search in.</param>
        /// <returns>
        /// The longest subsquence as new List of ints if such excsist. 
        /// If there are more than longest sequnces with equal elements returns 
        /// the first one in the given sequence.
        /// If all there are no sequences with equal Element returns null.
        /// </returns>
        public static List<int> GetLongestSubSequenceOfEqualElements(List<int> sequence)
        {
            int? subSequenceEqualElementsValue = null;
            int subSequenceLength = 1;

            for (int i = 0; i < sequence.Count - 1; i++)
            {
                int? currentSubSequenceEqualElementsValue = null;
                int currentSubSequenceLength = 1;

                for (int j = i + 1; j < sequence.Count; j++)
                {
                    if (sequence[i] == sequence[j])
                    {
                        currentSubSequenceLength++;
                    }
                    else
                    {
                        currentSubSequenceEqualElementsValue = sequence[i];
                        break;
                    }
                }

                if (currentSubSequenceLength > subSequenceLength)
                {
                    subSequenceLength = currentSubSequenceLength;
                    subSequenceEqualElementsValue = currentSubSequenceEqualElementsValue;
                }
            }

            List<int> subSequence = GenerateSubSequenceWithEqualsElements(subSequenceEqualElementsValue, subSequenceLength);
            return subSequence;
        }

        private static List<int> GenerateSubSequenceWithEqualsElements(int? value, int length)
        {
            if (value == null)
            {
                return null;
            }

            List<int> sequence = new List<int>();
            int element = (int)value;

            for (int i = 0; i < length; i++)
            {
                sequence.Add(element);
            }

            return sequence;
        }
    }
}