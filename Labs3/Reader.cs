using System;
using System.Collections.Generic;
using System.IO;

namespace Labs3
{
    public class Reader
    {
        public string name { get; }
        public int code { get; }
        protected List<LibraryBook> BookList;

        public Reader(string name, int code)
        {
            this.name = name;
            this.code = code;
            BookList = new List<LibraryBook>();
        }

        public LibraryBook this[int index]
        {
            get
            {
                if (index<0 || index>=BookList.Count)
                    throw new ArgumentOutOfRangeException();
                return BookList[index];
            }
            set
            {
                if (index>=BookList.Count || index<0)
                    BookList.Add(value);
                else
                    BookList[index] = value;
            }
        }

        public int TakeBook(LibraryBook book)
        {
            if (book.isInStack())
            {
                book.GetFromStack();
                BookList.Add(book);
                return 1;
            }
            return 0;
        }
        public int ReturnBook(LibraryBook book)
        {
            if (!book.isInStack())
            {
                book.PutToStack();
                BookList.Remove(book);
                return 1;
            }
            return 0;
        }

        public void Serialize(string path)
        {
            string data = "";
            foreach (LibraryBook book in BookList)
                data += book.type + "\n" + book.code + "\n";
            File.WriteAllText(path, data);
        }

        public void Deserialize(string path)
        {
            string[] data = File.ReadAllLines("file.txt");
            BookList.Clear();
            for (int i = 0; i < data.Length/2; i++)
            {
                BookType type = BookType.Unknown;
                int code = Int32.Parse(data[i * 2 + 1]);
                switch (data[i * 2])
                {
                    case "Horror":
                        type = BookType.Horror;
                        break;
                    case "Comedy":
                        type = BookType.Comedy;
                        break;
                    case "Drama":
                        type = BookType.Drama;
                        break;
                }
                BookList.Add(new LibraryBook(type, code));
            }
        }
    }

    

}