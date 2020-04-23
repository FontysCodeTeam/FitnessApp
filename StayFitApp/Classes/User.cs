using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFitApp.Classes
{
    class User
    {
        public User(string username, string name)
        {
            this.username = username;

            this.name = name;
        }

        public string username;

        public string name;

    }
}
