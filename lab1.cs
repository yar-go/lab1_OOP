using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    class Author
    {
        public string firstName { get; set; }
        public string secondName { get; set; }
        public int old { get; set; }
        public Author(string firstName)
        {
            this.firstName = firstName;
            this.secondName = "";
            this.old = -1;
        }
        public Author(string firstName, string secondName)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.old = -1;
        }
        public Author(string firstName, string secondName, int old)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.old = old;
        }
        public override string ToString()
            { 
                if(this.secondName != "") return this.firstName + " " + this.secondName;
                else return this.firstName;
            }
    }

    class Publish { 
        public string name { get; set; }
        public int power { get; set; }
        public int year { get; }
        public string address { get; set; }
        public Publish(string name)
        {
            this.name = name;
            this.power = 0;
            this.year = 0;
            this.address = "Ukraine";
        }
        public Publish(string name, int power)
        {
            this.name = name;
            this.power = power;
            this.year = 0;
            this.address = "Ukraine";
        }
        public Publish(string name, int power, int year)
        {
            this.name = name;
            this.power = power;
            this.year = year;
            this.address = "Ukraine";
        }
        public Publish(string name, int power, int year, string address)
        {
            this.name=name;
            this.power = power;
            this.year = year;
            this.address = address;
        }
        public override string ToString()
        {
            if (this.year != 0) return this.name + " " + this.year;
            else return this.name;
        }
    }

    class Book
    {   
        public enum Cover
        {
            hard,
            soft,
        }
        public string title { get; }
        public Author author { get; }
        public Publish publish { get; }
        public int year { get; }
        public int pages { get; set; }
        public Cover cover { get; }
        public Book(string title, Author author, Publish publish, int year, int pages, Cover cover)
        {
            this.title = title;
            this.author = author;
            this.publish = publish;
            this.year = year;
            this.pages = pages;
            this.cover = cover;
        }
        public Book(string title, Author author, Publish publish, int year, int pages)
        {
            this.title = title;
            this.author = author;
            this.publish = publish;
            this.year = year;
            this.pages = pages;
            this.cover = Cover.hard;
        }
        public Book(string title, Author author, Publish publish, int year)
        {
            this.title = title;
            this.author = author;
            this.publish = publish;
            this.year = year;
            this.pages = 100;
            this.cover = Cover.hard;
        }
        public Book(string title, Author author, Publish publish)
        {
            this.title = title;
            this.author = author;
            this.publish = publish;
            this.year = 0;                      
            this.pages = 100;
            this.cover = Cover.hard;
        }
        public Book(string title, Author author)
        {
            this.title = title;
            this.author = author;
            this.publish = null;
            this.year = 0;                       
            this.pages = 100;
            this.cover = Cover.hard;
        }
        public Book(string title)
        {
            this.title = title;
            this.author = null;
            this.publish = null;
            this.year = 0;                      
            this.pages = 100;
            this.cover = Cover.hard;
        }
        public override string ToString()
        {
            if (this.author != null && this.year != 0) return this.title + " " +
                    this.author + " " + this.year + " " + this.pages+"p";
            else return this.title + " " + this.pages + "p";
        }
    }

    class Library
    {
        public string name { get; set; }
        private string town { get; set; }
        private List<Book> books = new List<Book>();
        public Book[] getBooks()
        {
            return this.books.ToArray();
        }
        public void addBook(Book book)
        {
            this.books.Add(book);
            Console.WriteLine("Book \"" + book + "\" has been added");
        }
        public override string ToString()
        {
            return this.name + " / " + this.town;
        }
        public Library(string name, string town, Book[] books)
        {
            this.name = name;
            this.town = town;

            this.books = (List <Book>)books.ToList();
        }
        public Library(string name, string town)
        {
            this.name = name;
            this.town = town;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Author a = new Author("Alexandr", "Pushkin");
            Publish sun = new Publish("SUN", 100, 1996, "Kiev");
            Book book1 = new Book("Prorok", a, sun, 1996, 200, Book.Cover.hard);
            Book book2 = new Book("Fairy tales", a, sun, 1996, 120, Book.Cover.soft);
            Library library = new Library("Odessa Library", "Odessa");

            library.addBook(book1);
            library.addBook(book2);

            Console.WriteLine(library.getBooks()[0]);
            Console.WriteLine("\nAvailable books:");
            foreach (Book book in library.getBooks())
            {
                Console.WriteLine(book);
            }
        }
    }
}
