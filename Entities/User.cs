using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Entities
{
    internal class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User()
        {

        }
        public User(string FirstName, string LastName, int UserId)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.UserId = UserId;
        }
    }
}
