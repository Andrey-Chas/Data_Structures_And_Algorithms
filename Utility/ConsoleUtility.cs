using System;
using System.Collections.Generic;
using System.IO;

namespace Utility
{
    public static class ConsoleUtility
    {
        public static IEnumerable<T> ReadSequenceOfElements<T>() where T : IComparable
        {
            Console.WriteLine($"Please enter a sequence of elements of type {typeof(T)}.");
            Console.WriteLine("Elements have to be entered on a separate lines.");
            Console.WriteLine("Add empty element to finish inserting the elements.");
            Console.WriteLine();

            var numbers = new List<T>();
            string input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                T number = (T)Convert.ChangeType(input, typeof(T));
                numbers.Add(number);

                input = Console.ReadLine();
            }

            return numbers;
        }

        public static string GetFileTextContent(string fullPath)
        {
            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException($"File does not exist. File name: {fullPath}");
            }

            string textContent = string.Empty;

            using (var reader = new StreamReader(fullPath))
            {
                textContent = reader.ReadToEnd();
            }

            return textContent;
        }
    }
}
