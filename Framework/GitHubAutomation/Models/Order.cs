using System;
using System.Text;


namespace GitHubAutomation.Models
{
    public class Order
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string DepartingTime { get; set; }
        public string ReturningTime { get; set; }

        public Order(string origin, string destination, string departingTime, string returningTime)
        {
            Origin = origin;
            Destination = destination;
            DepartingTime = departingTime;
            ReturningTime = returningTime;
        }
    }
}
