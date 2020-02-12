using System;
using System.Text;
using GitHubAutomation.Models;


namespace GitHubAutomation.Services
{
    class CreatingUser
    {
        public static User TestUser()
        {
            return new User(TestDataReader.GetTestData("UserEmail"), TestDataReader.GetTestData("UserPassword"));
        }

        public static User IncorrectUser()
        {
            return new User(TestDataReader.GetTestData("IncorrectUserEmail"), TestDataReader.GetTestData("IncorrectUserEmail"));
        }
    }
}
