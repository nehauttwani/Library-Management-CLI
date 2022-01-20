using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Entities;

namespace LibraryManager.ViewModels
{
    internal class BookIssueViewModel
    {
        UserViewModel userFunctions = new UserViewModel();
        BookViewModel bookFunctions = new BookViewModel();
        List<BookIssue> IssuedBooks = new List<BookIssue>();
        List<BookReturn> ReturnedBooks = new List<BookReturn>();
        int counter = 0;

        public int Issue(int UserID, int BookID, object BookFunctions, object UserFunctions)
        {
            bookFunctions = (BookViewModel)BookFunctions;
            userFunctions = (UserViewModel)UserFunctions;
            if (userFunctions.Validate(UserID) && bookFunctions.Validate(BookID))
            {

                IssuedBooks.Add(new BookIssue() { BookID = BookID, UserID = UserID, BookIssueId = counter + 1, DateOfIssue = DateTime.UtcNow });
                bookFunctions.UpdateOnIssue(BookID);
            }
            return ++counter;
        }

        public void Return(int UserID, int BookIssueId, object BookFunctions, object UserFunctions)
        {
            bookFunctions = (BookViewModel)BookFunctions;
            userFunctions = (UserViewModel)UserFunctions;
            if (ValidateBookIssueID(BookIssueId))
            {
                foreach (BookIssue item in IssuedBooks)
                {

                    if (item.BookIssueId == BookIssueId && item.UserID == UserID)
                    {
                        int BookId = item.BookID;
                        int UserId = item.UserID;
                        IssuedBooks.Remove(item);
                        ReturnedBooks.Add(new BookReturn() { BookID = BookId, UserID = UserId, BookIssueID = BookIssueId, DateOfReturn = DateTime.Today });
                        bookFunctions.UpdateOnReturn(BookId);
                        break;
                    }

                }
            }
        }
        public List<string> OnhandBooks(int UserID, object BookFunctions)
        {
            bookFunctions = (BookViewModel)BookFunctions;
            List<string> OnhandBooks = new List<string>();
            foreach (BookIssue item in IssuedBooks)
            {

                if (item.UserID == UserID)
                {
                    string BookName = bookFunctions.returnBookName(item.BookID);
                    OnhandBooks.Add(BookName);

                }

            }
            return OnhandBooks;
        }
        public Dictionary<int, string>  BookHistory(int UserID, object BookFunctions)
        {
            bookFunctions = (BookViewModel)BookFunctions;
            Dictionary<int, string> BookHistory = new Dictionary<int, string>();

           
                foreach (BookIssue item in IssuedBooks)
                {

                    string BookName = bookFunctions.returnBookName(item.BookID);
                    if (item.UserID == UserID)
                    {
                        BookHistory.Add(item.BookIssueId, BookName + " - Issued");

                    }

                }


                foreach (BookReturn item in ReturnedBooks)
                {
                    if (item.UserID == UserID)
                    {
                        string BookName = bookFunctions.returnBookName(item.BookID);
                        BookHistory.Add(item.BookIssueID,BookName + " - Returned");

                    }
                }
            
            return BookHistory;
        }
        public List<string> AllIssuedBooks(object BookFunctions, object UserFunctions)
        {
            bookFunctions = (BookViewModel)BookFunctions;
            userFunctions = (UserViewModel)UserFunctions;
            List<string> history = new List<string>();
            foreach (BookIssue item in IssuedBooks)
            {
                string user = userFunctions.returnUserName(item.UserID);
                string book = bookFunctions.returnBookName(item.BookID);
                history.Add(user + " " + book + Environment.NewLine);
            }
            return history;
        }
        public List<string> AllReturnedBooks(object BookFunctions)
        {
            bookFunctions = (BookViewModel)BookFunctions;
            List<string> history = new List<string>();
            foreach (BookReturn item in ReturnedBooks)
            {

                string book = bookFunctions.returnBookName(item.BookID);
                history.Add(book);
            }
            return history;
        }
        public bool ValidateBookIssueID(int BookIssueID)
        {
            foreach (BookIssue x in IssuedBooks)
            {

                if (x.BookIssueId.Equals(BookIssueID))
                {
                    return true;
                }
            }
            return false;
        }



        public bool ValidateUser(int UserID)
        {
            foreach (BookIssue x in IssuedBooks)
            {

                if (x.UserID.Equals(UserID))
                {
                    return true;
                }
            }
            return false;
        }
        public bool ValidateBook(int BookId)
        {
            foreach (BookIssue x in IssuedBooks)
            {

                if (x.BookID.Equals(BookId))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
