using System;
using System.Text;


namespace GitHubAutomation.Models
{
    public class Location
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Place { get; set; }

        public Location(string pickUpCountry, string pickUpCity, string pickUpPlace)
        {
            Country = pickUpCountry;
            City = pickUpCity;
            Place = pickUpPlace;
        }
    }
}
