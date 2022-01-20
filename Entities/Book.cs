using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Entities
{
    class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Copies { get; set; }


        public Book(int BookID, string Title, string Author, int Copies)
        {
            this.BookID = BookID;
            this.Title = Title;
            this.Author = Author;
            this.Copies = Copies;
        }

        public Book()
        {
        }

        
    }
}
