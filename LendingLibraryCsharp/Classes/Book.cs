using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingLibraryCsharp.Classes
{
    internal class Book
    {
        public string Title { get; set; }
        public int NumOfPages { get; set; }
        public Author Author { get; set; }
    }
    public class Author
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; }
    }
}
