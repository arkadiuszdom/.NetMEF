using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.IO;
using System.Reflection;
using Reflection;
using System.Linq;
using AppInterfaces;
using XMLSerializerProject;
using FileLoggerProject;

namespace SerializerTest
{
    [TestClass]
    public class XMLSerializerTests
    {
        private XMLSerializer repo = new XMLSerializer();
        private const string repoPath = "testrepo.xml";
        private ILogger log = new FileLogger();

        Shelf shelf = CreateBookShelf();

        [TestMethod]
        public void TestXmlFileExists()
        {
            repo.Serialize(shelf, repoPath, log);

            Assert.IsTrue(File.Exists(repoPath));
        }
        [TestMethod]
        public void TestXmlEqualCount()
        {
            Shelf deserializedShelf = repo.Deserialize<Shelf>(repoPath, log);

            Assert.AreEqual(shelf.Authors.Count, deserializedShelf.Authors.Count);
            Assert.AreEqual(shelf.Books.Count, deserializedShelf.Books.Count);
        }
        [TestMethod]
        public void TestXmlEqualName()
        {
            Shelf deserializedShelf = repo.Deserialize<Shelf>(repoPath, log);

            Assert.AreEqual(shelf.Authors[0].Name, deserializedShelf.Authors[0].Name);
        }

        private static Shelf CreateBookShelf()
        {
            int booksCount = 20;
            List<Book> books = new List<Book>();

            for (int i = 0; i < booksCount; i++)
            {
                books.Add(new Book() { Title = "Book" + i });
            }

            int authorsCount = 10;
            List<Author> authors = new List<Author>();

            for (int i = 0; i < authorsCount; i++)
            {
                authors.Add(new Author() { Name = "Author" + i });
            }

            for (int i = 0; i < authorsCount; i++)
            {
                authors[i].Books.Add(books[2 * i]);
                books[2 * i].Author = authors[i];

                authors[i].Books.Add(books[2 * i + 1]);
                books[2 * i + 1].Author = authors[i];
            }

            Shelf shelf = new Shelf() { Authors = authors, Books = books };
            return shelf;
        }

        [DataContract(IsReference = true, Name = "Shelf")]
        private sealed class Shelf
        {
            [DataMember()]
            public List<Author> Authors
            {
                get { return authors; }
                set
                {
                    if (value != null)
                        authors = new List<Author>(value);
                    else
                        authors = new List<Author>();
                }
            }

            [DataMember()]
            public List<Book> Books
            {
                get { return books; }
                set
                {
                    if (value != null)
                        books = new List<Book>(value);
                    else
                        books = new List<Book>();
                }
            }

            public Shelf()
            {
                authors = new List<Author>();
                books = new List<Book>();
            }

            private List<Book> books;
            private List<Author> authors;
        }

        [DataContract(IsReference = true, Name = "Author")]
        private sealed class Author
        {
            [DataMember]
            public string Name { get; set; }

            [DataMember()]
            public List<Book> Books
            {
                get { return books; }
                set
                {
                    if (value != null)
                        books = new List<Book>(value);
                    else
                        books = new List<Book>();
                }
            }

            public Author()
            {
                Books = new List<Book>();
            }

            private List<Book> books;
        }

        [DataContract(IsReference = true, Name = "Book")]
        private sealed class Book
        {
            [DataMember]
            public Author Author { get; set; }
            [DataMember]
            public string Title { get; set; }
        }
    }
}
