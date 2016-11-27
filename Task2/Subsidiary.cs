using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Subsidiary
    {
        public class IntComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                int xCount = CountDigits(x);
                int yCount = CountDigits(y);
                return x.CompareTo(y);
            }

            private int CountDigits(int a)
            {
                int aCount = 0;
                while (a != 0)
                {
                    a /= 10;
                    ++aCount;
                }
                return aCount;
            }
        }

        public class StringComparer : IComparer<string>
        {
            public int Compare(string x, string y) => x.Length.CompareTo(y.Length);
        }

        public class BooksPublisherComparer : IComparer<Book>
        {
            public int Compare(Book x, Book y) => x.Publisher.CompareTo(y.Publisher);
        }

        public struct Point
        {
            int X { get; }
            int Y { get; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }

}
