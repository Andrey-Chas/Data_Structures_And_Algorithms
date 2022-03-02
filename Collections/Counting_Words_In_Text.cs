using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Utility;

namespace Collections
{
    public static class Counting_Words_In_Text
    {
        public static void RunTheProgram()
        {

            var contentOfTextFile = ConsoleUtility.GetFileTextContent("../../../Words.txt");

            var textWithoutPunctuation = RemovePunctuation(contentOfTextFile);

            var countedWords = CountWordsInText(textWithoutPunctuation);

            Output(countedWords, contentOfTextFile);
        }

        public static IList<string> RemovePunctuation(string text)
        {
            string textWithoutPunctuation = Regex.Replace(text, @"[^A-Za-z]+", " ");

            string[] textAsArr = textWithoutPunctuation.ToLower().Trim().Split(' ');

            return textAsArr.ToList();
        }

        public static IDictionary<string, int> CountWordsInText(IList<string> text)
        {
            var dictionaryOfCountedWords = new Dictionary<string, int>();

            foreach (var item in text)
            {
                if (dictionaryOfCountedWords.ContainsKey(item))
                {
                    dictionaryOfCountedWords[item] = dictionaryOfCountedWords[item] + 1;
                }

                else
                {
                    dictionaryOfCountedWords[item] = 1;
                }
            }

            return dictionaryOfCountedWords;
        }

        public static void Output(IDictionary<string, int> dictionaryOfCountedWords, string text)
        {
            var dictionaryOfCountedWordsSorted = dictionaryOfCountedWords.OrderBy(x => x.Value);

            Console.WriteLine("Words counted from the following text:");
            Console.WriteLine($"{text}");
            Console.WriteLine();

            foreach (var pair in dictionaryOfCountedWordsSorted)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
