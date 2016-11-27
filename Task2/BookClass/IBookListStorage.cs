using System.Collections.Generic;

namespace Task2
{
    public interface IBookListStorage<T>
    {
        void WriteBooks(IEnumerable<T> books);
        IEnumerable<T> ReadBooks();
    }
}