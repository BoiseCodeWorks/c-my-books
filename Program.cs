using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace console_library
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var name = "Library of Congress";
            var address = "123 Fake St.";
            var LibraryOfCongress = new Library(name, address);

            Book constitution = new Book("Constitution", "Lots of People");
            Book magnaCarta = new Book("Magna Carta", "The English");
            Book billOfRights = new Book("Bill of Rights", "Some other people");
            Book schoolHouseRock = new Book("School House Rock", "PBS", true);
            LibraryOfCongress.AddBook(constitution);
            LibraryOfCongress.AddBook(magnaCarta);
            LibraryOfCongress.AddBook(billOfRights);
            LibraryOfCongress.AddBook(schoolHouseRock);

            LibraryOfCongress.Greet();

            LibraryOfCongress.SeeAvailableBooks();

        }
    }

    public class Book
    {
        public string Title;
        public string Author;
        public bool CheckedOut;
        public Book(string title, string author, bool checkedOut = false)
        {
            Title = title;
            Author = author;
            CheckedOut = checkedOut;
        }
    }

    public class Library
    {
        public List<Book> Books = new List<Book>();
        private string Name;
        private string Address;

        public Library(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void CheckOut(int index)
        {
            Books[index -1].CheckedOut = true;
        }

        public void CheckIn(Book book)
        {
            book.CheckedOut = false;
        }

        public void SeeAvailableBooks()
        {
            for (var i = 0; i < Books.Count; i++)
            {
                if (!Books[i].CheckedOut)
                {
                    Console.WriteLine($"{i + 1}: {Books[i].Title}");
                }
            }
        }

        public void SeeAllBooks()
        {
            for (var i = 0; i < Books.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {Books[i].Title}, In Store: {Books[i].CheckedOut}");
            }
        }

        public void Greet()
        {
            Console.WriteLine($"Welcome to the {Name}.");
            Console.WriteLine($"Here is a list of our available books.");
            GetBookChoice();
        }

        private void GetBookChoice()
        {
            SeeAvailableBooks();
            Console.Write("Which book would you like to checkout? ");
            var selection = Console.ReadLine();
            var choice = ValidateSelection(selection);
            if(choice != 0){
                CheckOut(choice);
            }else{
                GetBookChoice();
            }
        }

        private int ValidateSelection(string selection)
        {
            int valid;
            int.TryParse(selection, out valid);
            return valid;
        }
    }
}
