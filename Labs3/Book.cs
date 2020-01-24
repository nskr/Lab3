using System;
using System.Collections.Generic;
using System.Text;

namespace Labs3
{
    public enum BookType : byte
    {
        Horror = 1,
        Comedy = 2,
        Drama = 3,
        Unknown = 255
    }
    public abstract class Book
    {
        public BookType type;
        public int code { get; set; }

        public Book(BookType type, int code)
        {
            this.type = type;
            this.code = code;
        }
        public abstract int PutToStack();

        public virtual int GetFromStack()
        {
            return 1;
        }
    }
}
