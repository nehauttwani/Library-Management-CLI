using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Entities;

namespace LibraryManager.ViewModels
{
    internal class UserViewModel : Abstract, IUserViewModel
    {
        
        List<User> users = new List<User>();
        int counter = 0;
        public UserViewModel()
        {
            users.Add(new User("neha", "uttwani", 1));
            users.Add(new User("niharika", "thakur", 2));
            counter=users.Count();
        }

        
        public override int Add(object obj)
        {
            //User newUser = (User)obj;
            //newUser.UserId = users.Max(x => x.UserId) + 1;
            users.Add(new User() { FirstName = ((User)obj).FirstName, LastName = ((User)obj).LastName, UserId = counter + 1 });
            return counter++;
        }



        public override void Delete(int Id)
        {
            
            foreach (User item in users)
            {

                if (item.UserId == Id)
                {
                    

                    users.Remove(item);
                    break;
                    
                }

            }
        }




        public override void Edit(int Id, object obj)
        {
            foreach (User item in users)

            {
                if (item.UserId == Id)
                {
                    item.FirstName = ((User)obj).FirstName;
                    item.LastName = ((User)obj).LastName;
                    break;
                }
            }
        }

        public List<User> Search(string input)
        {
            List<User> result = new List<User>();


            foreach (User user in users)
            {

                result = users.FindAll(x => x.FirstName.Contains(input.ToLower()) || x.LastName.Contains(input.ToLower()));

            }

            return result;
        }


        public bool Validate(int UserID)
        {
            foreach (User x in users)
            {

                if (x.UserId.Equals(UserID))
                {
                    return true;
                }
            }
            return false;
        }
        public string returnUserName(int UserID)
        {
            foreach (User x in users)
            {

                if (x.UserId.Equals(UserID))
                {
                    return (x.FirstName + " " + x.LastName);

                }

            }
            return null;
        }


    }
}




