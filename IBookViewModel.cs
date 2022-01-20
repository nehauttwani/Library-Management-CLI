using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Entities;

namespace LibraryManager
{
    internal interface IBookViewModel
    {
        public List<Book> Search(string input);
        public bool Validate(int BookID);
        public void UpdateOnIssue(int BookID);
        public void UpdateOnReturn(int BookID);
        public string returnBookName(int BookID);

    }
}
