using System;
using System.Text;
using GitHubAutomation.Models;


namespace GitHubAutomation.Services
{
    class CreatingOrder
    {
        public static Order WithOrderProperties()
        {
            DateTime dateAndTime = DateTime.Now;
            var today = dateAndTime.ToString("MM/dd/yyyy");
            var tommorow = dateAndTime.AddDays(1).ToString("MM/dd/yyyy");
            return new Order(
                TestDataReader.GetTestData("Origin"),
                TestDataReader.GetTestData("Destination"),
                today,
                tommorow);
        }
    }
}
