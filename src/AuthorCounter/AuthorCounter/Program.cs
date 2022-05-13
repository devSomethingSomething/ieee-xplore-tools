using System;
using System.IO;
using System.Linq;

namespace AuthorCounter
{
    public class Program
    {
        private static string path;

        private static string[] lines;

        private static void Main()
        {
            GetPath();

            GetLines();

            WriteResultsToFile();

            Console.ReadKey(true);
        }

        private static void GetPath()
        {
            Console.Write("Enter a path: ");
            path = Console.ReadLine();
        }

        private static void GetLines()
        {
            lines = File.ReadAllLines(path);
        }

        private static int CountAuthors(string authorList, char charToCount)
        {
            return authorList.Count(c => c == charToCount) + 1;
        }

        private static void WriteResultsToFile()
        {
            using StreamWriter streamWriter = new StreamWriter("results.txt", false);

            foreach (var line in lines)
            {
                streamWriter.WriteLine(CountAuthors(line, ';'));
            }
        }
    }
}
