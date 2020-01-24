using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labs3;
using System;
using System.IO;

namespace Labs3_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBookCreate()
        {
            Book newBook = new LibraryBook(BookType.Comedy, 23);

            Assert.AreEqual(BookType.Comedy, newBook.type);
            Assert.AreEqual(23, newBook.code);
        }
        [TestMethod]
        public void TestLibraryBookCreate()
        {
            LibraryBook newBook = new LibraryBook(BookType.Comedy, 23);

            Assert.AreEqual(BookType.Comedy, newBook.type);
            Assert.AreEqual(23, newBook.code);
        }

        [TestMethod]
        public void TestLibraryBookUsing()
        {
            LibraryBook newBook = new LibraryBook(BookType.Comedy, 23);
            int res1 = newBook.GetFromStack();
            bool res2 = newBook.isInStack();
            int res3 = newBook.PutToStack();
            bool res4 = newBook.isInStack();
            Assert.AreEqual(0, res1);
            Assert.AreEqual(false, res2);
            Assert.AreEqual(1, res3);
            Assert.AreEqual(true, res4);
        }
        [TestMethod]
        public void TestReaderCreate()
        {
            Reader newReader = new Reader("Mark", 1312);

            Assert.AreEqual("Mark", newReader.name);
            Assert.AreEqual(1312, newReader.code);
        }

        [TestMethod]
        public void TestReaderUsing()
        {
            LibraryBook newBook = new LibraryBook(BookType.Drama, 25);
            newBook.PutToStack();
            Reader newReader = new Reader("John", 1302);
            int res1 = newReader.TakeBook(newBook);
            int res2 = newReader.TakeBook(newBook);
            int res3 = newReader.ReturnBook(newBook);
            int res4 = newReader.ReturnBook(newBook);
            Assert.AreEqual(1, res1);
            Assert.AreEqual(0, res2);
            Assert.AreEqual(1, res3);
            Assert.AreEqual(0, res4);

            LibraryBook newBook2 = new LibraryBook(BookType.Horror, 29);
            newReader[0] = newBook2;
            Assert.AreEqual(newBook2, newReader[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Argument out of range attempted")]
        public void TestReaderUsingCatch()
        {
            Reader newReader = new Reader("John", 1302);
            LibraryBook newBook = newReader[0];
        }
        [TestMethod]
        public void TestReaderSerialization()
        {
            Reader newReader = new Reader("John", 1302);
            LibraryBook newBook = new LibraryBook(BookType.Drama, 25);
            newBook.PutToStack();
            newReader.TakeBook(newBook);
            newReader.Serialize("file.txt");
            string res = File.ReadAllText("file.txt");
            Assert.AreEqual("Drama\n25\n", res);
        }

        [TestMethod]
        public void TestReaderDeserialization()
        {
            Reader newReader = new Reader("John", 1302);
            TestReaderSerialization();
            newReader.Deserialize("file.txt");
            LibraryBook takenBook = newReader[0];
            LibraryBook newBook = new LibraryBook(BookType.Drama, 25);
            Assert.AreEqual(takenBook.code, newBook.code);
            Assert.AreEqual(takenBook.type, newBook.type);
        }
    }
}
