using NUnit.Framework;
using System;


namespace Task2.Tests
{
    [TestFixture()]
    public class BinarySearchTreeTests
    {
        [TestCase(new[] { 5, 2, 8, 1, 3, 4, 7, 9, 6 }, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        public void InOrder(int[] arrayInts, int[] expected)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(arrayInts);
            CollectionAssert.AreEqual(expected, tree.InOrder());
        }

        [TestCase(new[] { 5, 2, 8, 1, 3, 4, 7, 9, 6 }, new[] { 5, 2, 1, 3, 4, 8, 7, 6, 9 })]
        public void PreOrder(int[] arrayInts, int[] expected)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(arrayInts);
            CollectionAssert.AreEqual(expected, tree.PreOrder());
        }

        [TestCase(new[] { 5, 2, 8, 1, 3, 4, 7, 9, 6 }, new[] { 1, 4, 3, 2, 6, 7, 9, 8, 5 })]
        public void PostOrder(int[] arrayInts, int[] expected)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(arrayInts);
            CollectionAssert.AreEqual(expected, tree.PostOrder());
        }

        [TestCase(new[] { 55555, 666666, 333, 333, 22, 1, 4444 }, new[] { 1, 22, 333, 4444, 55555, 666666 })]
        public void InOrderIntComparer(int[] arrayInts, int[] expected)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(arrayInts, new Subsidiary.IntComparer());
            CollectionAssert.AreEqual(expected, tree.InOrder());
        }

        [TestCase(new[] { "g", "d", "s", "a", "p", "P", "z" }, new[] { "a", "d", "g", "p", "P", "s", "z" })]
        public void InOrderString(string[] arrayStrings, string[] expected)
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(arrayStrings);
            CollectionAssert.AreEqual(expected, tree.InOrder());
        }

        [TestCase(new[] { "ggg", "dd", "sssss", "a", "pppp", "zzzzzz" }, new[] { "a", "dd", "ggg", "pppp", "sssss", "zzzzzz" })]
        public void InOrderStrinComparer(string[] arrayStrings, string[] expected)
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(arrayStrings, new Subsidiary.StringComparer());
            CollectionAssert.AreEqual(expected, tree.InOrder());
        }

        static Book book1 = new Book("Есенин", "Первая книга", "Москва", 1955, 151);
        static Book book2 = new Book("Пушкин", "Вторая книга", "Российская Империя", 1955, 152);
        static Book book3 = new Book("Печета", "Третья книга", "Империя БГУ", 1945, 153);
        Book[] books = { book1, book2, book3 };

        public void InOrderBooks()
        {
            BinarySearchTree<Book> tree = new BinarySearchTree<Book>(books);
            Book[] expected = { book2, book1, book3 };
            CollectionAssert.AreEqual(expected, tree.InOrder());
        }

        public void InOrderBooksComparer()
        {
            BinarySearchTree<Book> tree = new BinarySearchTree<Book>(books, new Subsidiary.BooksPublisherComparer());
            Book[] expected = { book1, book2 };
            CollectionAssert.AreEqual(expected, tree.InOrder());
        }

        [ExpectedException(typeof(ArgumentException))]
        public void InOrderPoint2DDefaultComparerTest()
        {
            BinarySearchTree<Subsidiary.Point> tree = new BinarySearchTree<Subsidiary.Point>(
                new Subsidiary.Point[] { new Subsidiary.Point(1, 2), new Subsidiary.Point(3, 4) });
        }
    }
}