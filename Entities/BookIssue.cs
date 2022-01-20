using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Entities
{
    internal class BookIssue
    {
        public int UserID { get; set; }
        public int BookID { get; set; }
        public int BookIssueId { get; set; }
        public DateTime DateOfIssue { get; set; }
       
        public BookIssue()
        {

        }
        public BookIssue(int UserID, int BookID, int BookIssueId, DateTime DateOfIssue)
        {
            this.UserID = UserID;
            this.BookID = BookID;
            this.BookIssueId = BookIssueId;
            this.DateOfIssue = DateOfIssue;
        }
    }
    internal class BookReturn
    {
        public int UserID { get; set; }
        public int BookID { get; set; }
        public DateTime DateOfReturn { get; set; }
        public int BookIssueID { get; set; }
        
    }
}
