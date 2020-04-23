using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFitApp.Classes
{
    public class User
    {
        public User(string username, string name, int ID, DataTable history)
        {
            this.ID = ID;

            this.username = username;

            this.name = name;

            this.history = history;
        }

        public int ID;

        public string username;

        public string name;

        public DataTable history = new DataTable();

    }
}
