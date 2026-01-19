using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using domaindriven.Models;

namespace domaindriven
{
    public class ConsoleApp
    {
         List<Book> books = new List<Book>();

        public void Run()
        {
            bool run = true;
            while(run){
                Console.WriteLine("Welcome to book console app");
                Console.WriteLine("Menu:");
                Console.WriteLine("1. List Book");
                Console.WriteLine("2. Find Book");
                Console.WriteLine("3. Add Book");
                Console.WriteLine("4. Edit Book");
                Console.WriteLine("5. Delete Book");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice(1-6): ");
                int choice = int.Parse(Console.ReadLine());

                switch(choice){
                    case 1:
                     try{
                        ListBooks();
                     }catch(Exception e){
                        Console.WriteLine(e);
                     }
                     break;

                    case 2:
                     
                        Console.Write("Enter the Book Id to find: ");
                        int id = int.Parse(Console.ReadLine());
                        FindBook(id);
                        break;

                    case 3:
                        try{
                            AddBook();
                        }catch(Exception e){
                            Console.WriteLine(e);
                        }
                        break;

                    case 4:
                        
                        Console.Write("ENter the Book Id to edit: ");
                        int bid = int.Parse(Console.ReadLine());

                        EditBook(bid);
                        break;

                    case 5:
                        DeleteBook();
                        break;

                    case 6:
                        Console.WriteLine("Exetting the Book Console App. Good Bye!");
                        run = false;
                        break;
                     
                }
            }
        }

        private void ListBooks(){
            if(books.Count == 0){
                Console.WriteLine("No book found.");
                Console.WriteLine("Press any key to continue...");

            }else{
                foreach(var b in books){
                    Console.WriteLine($"Id: {b.Id}, Title: {b.Title}, Author: {b.Author}, Year: {b.Year}, Rating: {b.Rating}");
                }
            }
        }

        private void FindBook(int id){
            var b = books.Find(m => m.Id == id);
            if(b == null){
                Console.WriteLine($"Book with Id {id} not found.");
                return;
            }
            else{
                Console.WriteLine($"Found Book: Id: {b.Id}, Title: {b.Title}, Author: {b.Author}, Year: {b.Year}, Rating: {b.Rating}");
            }
        }

        private void AddBook(){
            Console.Write("Enter Book Title: ");
            string book_title = Console.ReadLine();

            Console.Write("Enter Book Author: ");
            string book_author = Console.ReadLine();

            Console.Write("Enter Book Year: ");
            int book_year = int.Parse(Console.ReadLine());

            Console.Write("Enter Book Rating: ");
            double book_rating = double.Parse(Console.ReadLine());

            int newId = books.Count > 0 ? books[books.Count -1].Id+1 : 1;

            Book newBook = new Book
            {
                Id = newId, Title = book_title, Author = book_author, Year = book_year, Rating = book_rating
            };

            books.Add(newBook);
            Console.WriteLine("Book added successfully");
        }

        private void EditBook(int id){
            var book = books.Find(m => m.Id == id);
            if(book == null){
                Console.WriteLine($"Book with Id {id} not found.");
                return;
            }else{
                Console.Write("Enter new Book Title: ");
                book.Title = Console.ReadLine();
                Console.Write(" Updated");

                Console.WriteLine();

                Console.Write("Enter new Book Author: ");
                book.Author = Console.ReadLine();
                Console.Write(" Updated");

                Console.WriteLine();

                Console.Write("Enter Book Year: ");
                book.Year = int.Parse(Console.ReadLine());

                Console.WriteLine();

                 Console.Write("Enter Book Rating: ");
                book.Rating = double.Parse(Console.ReadLine());

                Console.WriteLine();

                Console.WriteLine("Book edited successfully.");
                Console.WriteLine("Press any key to continue...");

            }
        }

        private void DeleteBook(){
            Console.WriteLine("Enter the Book Id to delete.");
            int id = int.Parse(Console.ReadLine());
            var book = books.Find(m => m.Id == id);

            if(book == null){
                Console.WriteLine($"Book with {id} not found.");
                return;
            }

            books.Remove(book);
            Console.WriteLine("Book deleted successfully.");
        }
    }
}

// Write methods here
// 1. ListBooks()
// 2. FindBook()
// 3. AddBook()
// 4. EditBook()
// 5. DeleteBook()
