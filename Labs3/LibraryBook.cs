using System;

namespace Labs3
{
    public class LibraryBook : Book
    {
        bool inStack;
        public LibraryBook(BookType type, int code) : base(type, code)
        {
            Console.WriteLine("Книга создана: {0}::{1}", type, code);
            inStack = false;
        }
        public override int PutToStack()
        {
            if (inStack)
            {
                Console.WriteLine("Книга уже на полке");
                return 0;
            }
            Console.WriteLine("Книга положена на полку");
            inStack = true;
            return 1;
        }
        public override int GetFromStack()
        {
            if (!inStack)
            {
                Console.WriteLine("Книга не на полке");
                return 0;
            }
            Console.WriteLine("Книга взята с полки");
            inStack = false;
            return 1;
        }
        public bool isInStack()
        {
            return inStack;
        }
    }
}
