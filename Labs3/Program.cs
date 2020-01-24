using System;

namespace Labs3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nТест создания книги\n");
            LibraryBook newBook = new LibraryBook(BookType.Comedy, 23);
            newBook.PutToStack();
            newBook.GetFromStack();
            Reader newReader = new Reader("Mark", 1312);
            Console.WriteLine("\nТест создания полки\n");
            newBook.PutToStack();
            Console.WriteLine(newReader.TakeBook(newBook));
            Console.WriteLine(newReader.TakeBook(newBook));
            Console.WriteLine(newReader.ReturnBook(newBook));
            Console.WriteLine(newReader.ReturnBook(newBook));
            newReader[0] = newBook;
            newReader[0].PutToStack();
            newReader.Serialize("1.txt");
        }
    }
}
