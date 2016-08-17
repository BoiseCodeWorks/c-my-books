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

            for(var i = 0; i < LibraryOfCongress.Books.Count; i++){
                Console.WriteLine($"{i + 1}: {LibraryOfCongress.Books[i].Title}");
            }
            // var i = 0;
            // foreach(var book in LibraryOfCongress.Books){
            //     Console.WriteLine($"{i + 1}: {book.Title}");
            // }

            Console.Write("Which book would you like to checkout? ");
            var selection = Console.ReadLine();
            if (selection == "1"){
                Console.WriteLine("You've selected one");
                LibraryOfCongress.CheckOut(constitution);
            }
            for(var i = 0; i < LibraryOfCongress.Books.Count; i++){
                if (!LibraryOfCongress.Books[i].CheckedOut){
                    Console.WriteLine($"{i + 1}: {LibraryOfCongress.Books[i].Title}");
                }
            }
        }
    }

    public class Book
    {
        public string Title;
        public string Author;
        public bool CheckedOut;
        public Book (string title, string author, bool checkedOut = false)
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

        public void CheckOut(Book book)
        {
            book.CheckedOut = true;
        }

        public void CheckIn(Book book)
        {
            book.CheckedOut = false;
        }


    }
}
