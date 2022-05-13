using System;
using System.Linq;

namespace AuthorCounter
{
    public class Program
    {
        private static void Main()
        {
            Console.ReadKey(true);
        }

        private static int CountAuthors(string authorList, char charToCount)
        {
            return authorList.Count(c => c == charToCount) + 1;
        }
    }
}
