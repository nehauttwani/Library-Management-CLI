using System;
using LibraryManager.Entities;
using LibraryManager.ViewModels;

namespace LibraryManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user;
            Book book = new Book();
            BookViewModel bookFunctions = new BookViewModel();
            UserViewModel userFunctions = new UserViewModel();
            BookIssueViewModel issueReturn = new BookIssueViewModel();


            string option = string.Empty;
            do
            {
                option = "6";
                string choice = userFunctions.ReturnToMainMenu(option);
                
                switch (choice)
                {
                    case "1":

                        string key = "";
                        do
                        {

                            Console.WriteLine("====================");
                            Console.WriteLine("     USER MENU      ");
                            Console.WriteLine("====================");
                            Console.WriteLine("1. Add User");
                            Console.WriteLine("2. Edit User");
                            Console.WriteLine("3. Delete User");
                            Console.WriteLine("4. OnHand Books");
                            Console.WriteLine("5  Issued Books History");
                            Console.WriteLine("6. Return to Main Menu");

                            Console.Write("Your Choice: ");
                            option = Console.ReadLine();
                            if (option == "1")
                            {
                                user = new User();
                                do
                                {
                                    Console.Write("First Name: ");
                                    user.FirstName = Console.ReadLine().ToLower();

                                    if (user.FirstName == string.Empty)
                                    {
                                        Console.WriteLine("Please enter valid fisrt name!");

                                    }
                                } while (user.FirstName == string.Empty);

                                do
                                {

                                    Console.Write("Last Name: ");
                                    user.LastName = Console.ReadLine().ToLower();
                                    if (user.LastName == "")
                                    {
                                        Console.WriteLine("Please enter valid Last name!");

                                    }
                                } while (user.LastName == "");

                                int UserID = userFunctions.Add(user);
                                Console.WriteLine("User added successfully with user ID - " + UserID);
                                Console.Write("Press any key for User Menu: ");
                                key = Console.ReadLine();

                            }


                            else if (option == "2")
                            {
                                user = new User();
                                int ID = 0;
                                Console.Write("Enter user ID: ");
                                ID = Convert.ToInt32(Console.ReadLine());
                                do
                                {

                                    Console.Write("First Name: ");
                                    user.FirstName = Console.ReadLine();
                                    if (user.FirstName == string.Empty)
                                    {
                                        Console.WriteLine("Please enter valid fisrt name!");

                                    }
                                } while (user.FirstName == string.Empty);

                                do
                                {

                                    Console.Write("Last Name: ");
                                    user.LastName = Console.ReadLine();
                                    if (user.LastName == "")
                                    {
                                        Console.WriteLine("Please enter valid Last name!");

                                    }
                                } while (user.LastName == "");

                                userFunctions.Edit(ID, user);

                                Console.Write("Press any key for User Menu: ");
                                key = Console.ReadLine();
                            }
                            else if (option == "3")
                            {

                                int ID = 0;
                                Console.Write("Enter user ID: ");
                                ID = Convert.ToInt32(Console.ReadLine());
                                BookIssueViewModel bookIssueFunctions = (BookIssueViewModel)issueReturn;
                                if (bookIssueFunctions.ValidateUser(ID))
                                {
                                    Console.WriteLine("User can't be deleted because there are some issued books!");

                                }
                                else
                                {

                                    userFunctions.Delete(ID);
                                    Console.WriteLine("User deleted successfully");
                                }
                                Console.Write("Press any key for User Menu: ");
                                key = Console.ReadLine();

                            }
                            else if (option == "4")
                            {
                                int ID = 0;
                                List<string> OnhandBooks = new List<string>();
                                Console.Write("Enter user ID: ");
                                ID = Convert.ToInt32(Console.ReadLine());
                                OnhandBooks = issueReturn.OnhandBooks(ID, bookFunctions);
                                foreach (string item in OnhandBooks)
                                {
                                    Console.WriteLine(item);
                                }
                                Console.Write("Press any key for User Menu: ");
                                key = Console.ReadLine();
                            }
                            else if (option == "5")
                            { 
                                int ID = 0;
                                Dictionary<int, string> History = new Dictionary<int, string>();
                                
                                Console.Write("Enter user ID: ");
                                ID = Convert.ToInt32(Console.ReadLine());
                                History = issueReturn.BookHistory(ID, bookFunctions).OrderBy(x => x.Key).ToDictionary(x => x.Key,x=> x.Value);
                                
                                foreach (var item in History)
                                {
                                    Console.WriteLine(item.Value);
                                }
                                Console.Write("Press any key for User Menu: ");
                                key = Console.ReadLine();
                            }
                            else if (option == "6")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Choice");
                            }




                        } while (key != "");

                        break;
                    case "2":
                        string var = "";
                        do
                        {
                            Console.WriteLine("====================");
                            Console.WriteLine("     BOOK MENU      ");
                            Console.WriteLine("====================");
                            Console.WriteLine("1. Add Book");
                            Console.WriteLine("2. Edit Book");
                            Console.WriteLine("3. Delete Book");
                            Console.WriteLine("4. Issued Books");
                            Console.WriteLine("5  Returned Books History");
                            Console.WriteLine("6. Return to Main Menu");
                            Console.Write("Your Choice: ");
                            option = Console.ReadLine();


                            if (option == "1")
                            {

                                do
                                {

                                    Console.Write("Book Title: ");
                                    book.Title = Console.ReadLine().ToLower();
                                    if (book.Title == string.Empty)
                                    {
                                        Console.WriteLine("Please enter valid Book Title!");

                                    }
                                } while (book.Title == "");

                                do
                                {

                                    Console.Write("Book Author: ");
                                    book.Author = Console.ReadLine().ToLower();
                                    if (book.Author == "")
                                    {
                                        Console.WriteLine("Please enter valid Book Author!");

                                    }
                                } while (book.Author == "");
                                do
                                {
                                    try
                                    {

                                        Console.Write("No. of available Copies: ");
                                        book.Copies = Convert.ToInt32(Console.ReadLine());
                                        if (book.Copies <= 0)
                                        {
                                            Console.WriteLine("Please enter valid No. of available Copies!");

                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                        book.Copies = 0;
                                    }
                                } while (book.Copies <= 0);



                                int BookiD = bookFunctions.Add(book);
                                Console.WriteLine("Book added successfully with Book ID - " + BookiD);


                            }
                            else if (option == "2")
                            {
                                int ID = 0;
                                Console.Write("Enter Book ID: ");
                                ID = Convert.ToInt32(Console.ReadLine());
                                do
                                {

                                    Console.Write("Book Title: ");
                                    book.Title = Console.ReadLine();
                                    if (book.Title == string.Empty)
                                    {
                                        Console.WriteLine("Please enter valid Book Title!");

                                    }
                                } while (book.Title == "");

                                do
                                {

                                    Console.Write("Book Author: ");
                                    book.Author = Console.ReadLine();
                                    if (book.Author == "")
                                    {
                                        Console.WriteLine("Please enter valid Book Author!");

                                    }
                                } while (book.Author == "");
                                do
                                {
                                    try
                                    {

                                        Console.Write("No. of available Copies: ");
                                        book.Copies = Convert.ToInt32(Console.ReadLine());
                                        if (book.Copies <= 0)
                                        {
                                            Console.WriteLine("Please enter valid No. of available Copies!");

                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                        book.Copies = 0;
                                    }
                                } while (book.Copies <= 0);
                                bookFunctions.Edit(ID, book);

                            }
                            else if (option == "3")
                            {

                                Console.Write("Enter Book Id: ");
                                book.BookID = Convert.ToInt32(Console.ReadLine());
                                BookIssueViewModel bookIssueFunctions = (BookIssueViewModel)issueReturn;
                                if (bookIssueFunctions.ValidateUser(book.BookID))
                                {
                                    Console.WriteLine("Book can't be deleted because It is issued to some users!");

                                }
                                else
                                {
                                    bookFunctions.Delete(book.BookID);
                                    Console.WriteLine("Book deleted successfully");
                                }

                            }
                            else if (option == "4")
                            {
                                List<string> History = new List<string>();
                                History = issueReturn.AllIssuedBooks(bookFunctions, userFunctions);
                                foreach (string item in History)
                                {
                                    Console.WriteLine(item);
                                }

                            }
                            else if (option == "5")
                            {
                                List<string> History = new List<string>();
                                History = issueReturn.AllReturnedBooks(bookFunctions);
                                foreach (string item in History)
                                {
                                    Console.WriteLine(item);
                                }
                            }


                            else if (option == "6")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Choice");
                            }

                            Console.Write("Press any key for Book Menu: ");
                            var = Console.ReadLine();
                        } while (var != "");

                        break;
                    case "3":
                        List<User> result1 = new List<User>();

                        Console.WriteLine("Enter the User info: ");
                        string userInput = Console.ReadLine();
                        result1 = userFunctions.Search(userInput);
                        if (result1.Count == 0)
                        {
                            Console.WriteLine("No Users found!");
                        }
                        else
                        {

                            Console.WriteLine("The Users matching with the given input: ");
                            foreach (User s in result1)
                            {
                                Console.WriteLine("First Name: " + s.FirstName);
                                Console.WriteLine("Last Name: " + s.LastName);
                                Console.WriteLine("UserID: " + s.UserId + "\n");

                            }
                        }
                        option = "6";
                        break;
                    case "4":
                        List<Book> result = new List<Book>();
                        Console.WriteLine("Enter the Bookname: ");
                        string input = Console.ReadLine();
                        result = bookFunctions.Search(input);
                        if (result.Count == 0)
                        {
                            Console.WriteLine("No books found!");

                        }
                        else
                        {

                            Console.WriteLine("The Books matching with the given input");
                            foreach (Book s in result)
                            {
                                Console.WriteLine("Title: " + s.Title);
                                Console.WriteLine("Author: " + s.Author);
                                Console.WriteLine("No. of available copies: " + s.Copies + "\n");

                            }

                        }
                        option = "6";
                        break;
                    case "5":

                        Console.WriteLine("\t 1.Issue");
                        Console.WriteLine("\t 2.Return");
                        Console.Write("Which operation you want to perform? ");
                        string selection = Console.ReadLine();
                        if (string.IsNullOrEmpty(selection) || (selection != "1" && selection != "2"))
                        {
                            Console.WriteLine("Invalid input. Try again!");
                            continue;
                        }
                        if (selection == "1")
                        {
                            Console.Write("Enter Book Id: ");
                            int bookId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter User Id: ");
                            int userId = Convert.ToInt32(Console.ReadLine());
                            int BookIssueID = issueReturn.Issue(userId, bookId, bookFunctions, userFunctions);
                            Console.WriteLine("Book Issued Succesfully with issue ID - " + BookIssueID);
                            option = "6";
                        }
                        else
                        {

                            Console.Write("Enter User Id: ");
                            int userId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter Book-Issue Id: ");
                            int bookIssueId = Convert.ToInt32(Console.ReadLine());
                            issueReturn.Return(userId, bookIssueId, bookFunctions, userFunctions);
                            Console.WriteLine("Book Returned Succesfully");
                            option = "6";

                        }

                        break;
                    case "6":
                        Console.Write("Do you want to exit the app?(yes/no): ");
                        string answer = Console.ReadLine();
                        if (answer == "yes")
                        {
                            Console.Clear();
                            Environment.Exit(0);

                            break;
                        }
                        else
                        {
                            option = "6";
                        }
                        break;
                }

                Console.ReadKey();

            } while (option == "6");


        }
    }
}

