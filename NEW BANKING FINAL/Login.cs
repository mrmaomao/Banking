using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEW_BANKING_FINAL
{
    class Login
    {
        private string userName;
        private string password;

        public Login(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
