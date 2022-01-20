using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    public abstract class Abstract
    {
        public abstract int Add(object obj);

        public abstract void Delete(int Id);
        public abstract void Edit(int Id, object obj);
        public string ReturnToMainMenu(string Menuoption)
        {
            string MainMenu = string.Empty;
            MainMenu += "***************************" + Environment.NewLine;
            MainMenu += "*     LIBRARY MANAGER     *" + Environment.NewLine;
            MainMenu += "***************************" + Environment.NewLine;
            MainMenu += "====================" + Environment.NewLine;
            MainMenu += "     MAIN MENU      " + Environment.NewLine;
            MainMenu += "====================" + Environment.NewLine;
            MainMenu += "1. Users Management" + Environment.NewLine;
            MainMenu += "2. Books Management" + Environment.NewLine;
            MainMenu += "3. Search Users" + Environment.NewLine;
            MainMenu += "4. Search Books" + Environment.NewLine;
            MainMenu += "5. Issue / Return Books" + Environment.NewLine;
            MainMenu += "6. Exit" + Environment.NewLine;
            Console.WriteLine(MainMenu);
            Console.Write("Your Option: ");
            string choice = Console.ReadLine();
            return choice;
        }
    }
}
