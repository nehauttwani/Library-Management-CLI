using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Entities;

namespace LibraryManager
{
    internal interface IUserViewModel
    {
        public List<User> Search(string input);
        public bool Validate(int UserID);
        public string returnUserName(int UserID);

    }
}
