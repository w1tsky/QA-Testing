using System;
using System.Text;
using GitHubAutomation.Models;

namespace GitHubAutomation.Services
{
    class CreatingOrder
    {
       public static Location PickUpFields()
       {
            return new Location(TestDataReader.GetTestData("PickUpCountry"), TestDataReader.GetTestData("PickUpCity"), TestDataReader.GetTestData("PickUpPlace"));
       }

        public static Location ReturnFields()
        {
            return new Location(TestDataReader.GetTestData("ReturnCountry"), TestDataReader.GetTestData("ReturnCity"), TestDataReader.GetTestData("ReturnPlace"));
        }
    }
}
