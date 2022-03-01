using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace Collections
{
    public static class Extract_Elements
    {
        public static void RunTheProgram()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../../Extract_Elements.txt"));
#endif

            var elements = ConsoleUtility.ReadSequenceOfElements<string>().ToList();

            var numberOfOddElements = FindOddElements(elements);

            var numberOfOddElements2 = FindOddAndEvenElements2(elements, isOddNumberOfTimes: true);

            Output(numberOfOddElements, elements);

            Output2(numberOfOddElements2);
        }

        // Using dictionary

        public static IDictionary<T, int> FindOddElements<T>(List<T> collection)
        {
            var dictionaryOfEvenAndOdd = new Dictionary<T, int>();

            foreach (var item in collection)
            {
                if (dictionaryOfEvenAndOdd.ContainsKey(item))
                {
                    dictionaryOfEvenAndOdd[item] = dictionaryOfEvenAndOdd[item] + 1;
                }

                else
                {
                    dictionaryOfEvenAndOdd[item] = 1;
                }
            }

            return dictionaryOfEvenAndOdd;
        }
        
        // Using HashSet
        public static ISet<T> FindOddAndEvenElements2<T>(IList<T> collection, bool isOddNumberOfTimes)
        {
            var oddNumberOfTimes = new HashSet<T>();

            foreach (var item in collection)
            {
                if (oddNumberOfTimes.Add(item))
                {
                    oddNumberOfTimes.Add(item);
                }

                else
                {
                    oddNumberOfTimes.Remove(item);
                }
            }

            return oddNumberOfTimes;
        }

        public static void Output<T>(IDictionary<T, int> dictionaryOfEvenAndOdd, List<T> collection)
        {
            List<T> keysToDisplay = new List<T>();

            Console.WriteLine("Using dictionary");
            Console.WriteLine("Elements that are present odd number of times in the following array:");
            Console.WriteLine(string.Join(", ", collection));

            Console.WriteLine();

            foreach (var pair in dictionaryOfEvenAndOdd)
            {
                if (pair.Value % 2 != 0)
                {
                    keysToDisplay.Add(pair.Key);
                }
            }

            Console.WriteLine(string.Join(", ", keysToDisplay));
        }

        public static void Output2<T>(ISet<T> elements)
        {
            Console.WriteLine();
            Console.WriteLine("Using HashSet");
            Console.WriteLine(string.Join(", ", elements));
        }
    }
}
