using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace Collections
{
    public static class Number_Of_Occurrences
    {
        public static void RunTheProgram()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../../Number_Of_Occurrences.txt"));
#endif

            var elements = ConsoleUtility.ReadSequenceOfElements<double>().ToList();

            var numberOfOccurrences = FindOccurrencesOfTheElements(elements);

            Output(numberOfOccurrences, elements);
        }

        public static IDictionary<T, int> FindOccurrencesOfTheElements<T>(List<T> collection)
        {
            var dictionaryOfOccurrences = new Dictionary<T, int>();

            foreach (var item in collection)
            {
                if (dictionaryOfOccurrences.ContainsKey(item))
                {
                    dictionaryOfOccurrences[item] = dictionaryOfOccurrences[item] + 1;
                }

                else
                {
                    dictionaryOfOccurrences[item] = 1;
                }
            }

            return dictionaryOfOccurrences;
        }

        public static void Output<T>(IDictionary<T, int> dictionaryOfOccurrences, List<T> collcetion)
        {
            Console.WriteLine("Elements counted from the following array:");
            for (int i = 0; i < collcetion.Count; i++)
            {
                Console.Write($"{collcetion[i]} ");
            }

            Console.WriteLine();

            foreach (var pair in dictionaryOfOccurrences)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value} time(s)");
            }
        }
    }
}
