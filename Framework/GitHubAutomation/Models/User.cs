using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Models
{
    class User
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public User(string userEmail, string userPassword)
        {
            Email = userEmail;
            Password = userPassword;
        }
    }
}
