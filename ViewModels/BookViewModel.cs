using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Entities;

namespace LibraryManager.ViewModels
{
    internal class BookViewModel : Abstract, IBookViewModel
    {
        List<Book> books = new List<Book>();
        
        int counter = 0;
        public BookViewModel()
        {
            books.Add(new Book(1,"first Book", "first Author", 5));
            books.Add(new Book(2,"second Book", "second author", 2));
            counter=books.Count();
        }


        public override int Add(object obj)
        {
            books.Add(new Book() { BookID = counter + 1,  Title = ((Book)obj).Title, Author = ((Book)obj).Author, Copies = ((Book)obj).Copies });
            return counter++;
        }

        public override void Delete(int Id)
        {
            
            foreach (Book item in books)
            {

                if (item.BookID == Id)
                {
                    
                    
                    books.Remove(item);
                    break;
                   
                }

            }
        }

        public override void Edit(int Id, object obj)
        {
            foreach (Book item in books)

            {
                if (item.BookID == Id)
                {
                    item.Title = ((Book)obj).Title;
                    item.Author = ((Book)obj).Author;
                    item.Copies = ((Book)obj).Copies;
                    break;
                }
            }
        }

        public List<Book> Search(string input)
        {
            List<Book> result = new List<Book>();

            foreach (Book book in books)
            {

                result = books.FindAll(x => x.Title.Contains(input.ToLower()) || x.Author.Contains(input.ToLower()));

            }
            
            return result;

        }

        public bool Validate(int BookID)
        {
            
            foreach (Book x in books)
            {

                if (!x.Copies.Equals(0) && x.BookID.Equals(BookID))
                {
                    return true;
                }
            }
            return false;
        }

        public void UpdateOnIssue(int BookID)
        {
            foreach (Book x in books)
            {

                if (x.BookID.Equals(BookID))
                {
                    x.Copies -= 1;
                }
                
            }
        }
        public void UpdateOnReturn(int BookID)
        {
            foreach (Book x in books)
            {

                if (x.BookID.Equals(BookID))
                {
                    x.Copies += 1;
 
                }
            }
        }
        public string returnBookName(int BookID)
        {
            foreach (Book x in books)
            {

                if (x.BookID.Equals(BookID))
                {
                    return x.Title;

                }
                
            }
            return null;
        }


    }
}
