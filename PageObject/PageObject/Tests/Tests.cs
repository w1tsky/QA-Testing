using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObject.Pages;
using System;

namespace PageObject
{
    [TestFixture]
    class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void StartBrowserChrome()
        {
            driver = new ChromeDriver
            {
                Url = "https://www.expedia.com/"
            };
        }

        [TearDown]

        public void QuitDriver()

        {

            driver.Quit();

        }

        [Test]
        public void CheckAge()
        {
            DateTime dateAndTime = DateTime.Now;
            var today = dateAndTime.ToString("MM/dd/yyyy");


            var mainPage = new MainPage(driver);
            mainPage.originInput.SendKeys("Sydney");
            mainPage.destinationInput.SendKeys("Gold Coast");
            mainPage.departingInput.SendKeys(today);
            mainPage.retutningInput.SendKeys(today);
            mainPage.travelersInput.Click();
            mainPage.addChildren.Click();
            mainPage.submitBtn.Click();
            Assert.AreEqual(mainPage.errorMessage, "Please provide the ages of children below.");


        }



        [Test]
        public void MoreThanSixPessengers()
        {
            DateTime dateAndTime = DateTime.Now;
            var today = dateAndTime.ToString("MM/dd/yyyy");


            var mainPage = new MainPage(driver);
            mainPage.originInput.SendKeys("Sydney");
            mainPage.destinationInput.SendKeys("Gold Coast");
            mainPage.departingInput.SendKeys(today);
            mainPage.retutningInput.SendKeys(today);
            mainPage.travelersInput.Click();
            mainPage.addAdults.Click();
            mainPage.addAdults.Click();
            mainPage.addAdults.Click();
            mainPage.addAdults.Click();
            mainPage.addChildren.Click();
            mainPage.submitBtn.Click();
            Assert.AreEqual(mainPage.errorMessage, "We are only able to book between 1 and 6 travelers. Please adjust the number of travelers for your search.");


        }



    }
}