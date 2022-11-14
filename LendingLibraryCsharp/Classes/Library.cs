using LendingLibraryCsharp.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingLibraryCsharp.Classes
{
    internal class Library : ILibrary
    {
        private readonly Dictionary<string, Book> books = new Dictionary<string, Book>();

        //This property is used to count the number of books
        public int Count => books.Count;

        public void Add(string title, string firstName, string lastName, int numberOfPages)
        {
            Book book = new Book
            {//book object is created
                Title = title,
                Author = new Author
                {
                    FirstName = firstName,
                    LastName = lastName,
                },
                NumOfPages = numberOfPages,
            };//book added to dictionary
            books.Add(title, book);//adding whatever book we create to the dictionary
        }//Borrow a book
        public Book Borrow(string title)
        {
            if (!books.ContainsKey(title))
            {
                return null;
            }
            //find matching book
            Book book = books[title];
            //remove book from the library
            books.Remove(title);
            //return the book
            return book;
        }
        //return the book to the library
        public void Return(Book book)
        {
            books.Add(book.Title, book);
        }
        public IEnumerator<Book> GetEnumerator()
        {
            foreach (Book book in books.Values)
                yield return book;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
}
