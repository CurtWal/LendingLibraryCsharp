using System;
using System.Collections.Generic;
using System.Collections;
using LendingLibraryCsharp.Classes;

class Program
{//instantiate a new Library and a new Backpack
    private static readonly Library library = new Library();
    private static readonly BackPack<Book> bookBag = new BackPack<Book>();

    static void Main(string[] args)
    {
        //create our book dictionary
        LoadBooks();
        //run our program
        UserInterface();
    }
    static void UserInterface()
    {
        while (true)
        {
            //Our options
            Console.WriteLine("Welcome to the Manga Library.");
            Console.WriteLine("Please Select Your Option");
            Console.WriteLine("1. View All Books Available");
            Console.WriteLine("2. Add A New Book");
            Console.WriteLine("3. Borrow A Book From The Library. 'PLEASE RETURN'");
            Console.WriteLine("4. Return A Book To The Library");
            Console.WriteLine("5. View Your BackPack");
            Console.WriteLine("6. Exit");

            string answer = Console.ReadLine();

            //switch case for options
            switch (answer)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Manga In Stock");
                    Console.WriteLine("=======================================");
                    OutputBooks(library);
                    break;

                case "2":
                    Console.Clear();
                    AddBook();
                    Console.Clear();
                    break;

                case "3":
                    Console.Clear();
                    BorrowBook();
                    Console.Clear();
                    break;

                case "4":
                    Console.Clear();
                    ReturnBook();
                    Console.Clear();
                    break;

                case "5":
                    Console.Clear();
                    Console.WriteLine("=======================================");
                    OutputBooks(bookBag);
                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Invalid Option.... Please Try Again");
                    break;
            }
        }
    }
    static void LoadBooks()
    {
        library.Add("Re: Zero Starting Life in Another World", "Tappei", "Nagatsuki", 292);
        library.Add("KonoSuba", "Natsume", "Akatsuki", 176);
        library.Add("Attack On Titans", "Hajime", "Isayama", 208);
        library.Add("Grand Blue", "Kenji", "Inoue ", 192);
        // Tatsuki Fujimoto pages 192
    }
    static void OutputBooks(IEnumerable<Book> books)
    {
        int counter = 1;
        foreach(Book book in books)
        {
            Console.WriteLine($"{counter++}. {book.Title}, by: {book.Author.FirstName} {book.Author.LastName}, contains {book.NumOfPages} pages");
        }
        Console.WriteLine();
    }
    //  add a way for the user to add a book to the library
    private static void AddBook()
    {
        Console.WriteLine("Please input the following details: ");
        Console.WriteLine("Book Title: ");
        // ask for the book title
        string title = Console.ReadLine();

        Console.WriteLine("Author First Name: ");
        // ask for the firstname
        string first = Console.ReadLine();

        Console.WriteLine("Author Last Name: ");
        //ask for the lastname
        string last = Console.ReadLine();

        Console.WriteLine("Number of Pages: ");
        int numberOfPages = Convert.ToInt32(Console.ReadLine());

        library.Add(title, first, last, numberOfPages);
    }
    private static void BorrowBook()
    {
        Console.WriteLine("Borrow A Book");
        Console.WriteLine("=======================================");
        // go through all books available
        foreach (Book book in library)
        {
            Console.WriteLine(book.Title);
        }
        // ask which book to borrow
        Console.WriteLine();
        Console.WriteLine("Which Book would you like to borrow?");
        // assign the borrowed book to a variable
        string selection = Console.ReadLine();
        Book borrowed = library.Borrow(selection);
        //pack it in our bookbag
        bookBag.Pack(borrowed);
    }
    static void ReturnBook()
    {
        Console.WriteLine("Returning A Book");
        Console.WriteLine("=======================================");
        OutputBooks(bookBag);
        Console.WriteLine("Which book would you like to return?");
        int selection = Convert.ToInt32(Console.ReadLine());
        Book bookToReturn = bookBag.Unpack(selection - 1);
        Console.WriteLine("========");
        Console.WriteLine(bookToReturn);
        Console.WriteLine("Book returned to library");
        library.Return(bookToReturn);
    }
}