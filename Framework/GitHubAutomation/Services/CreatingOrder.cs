using System;
using System.Text;
using GitHubAutomation.Models;

namespace GitHubAutomation.Services
{
    class CreatingOrder
    {
       public static Order PickUpFields()
       {
            return new Order(TestDataReader.GetTestData("PickUpCountry"), TestDataReader.GetTestData("PickUpCity"), TestDataReader.GetTestData("PickUpPlace"));
       }

        public static Order ReturnFields()
        {
            return new Order(TestDataReader.GetTestData("ReturnCountry"), TestDataReader.GetTestData("ReturnCity"), TestDataReader.GetTestData("ReturnPlace"));
        }
    }
}
