using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumWebDriver
{
    [TestFixture]
    class ExpediaTests
    {
        private IWebDriver webDriver;

        [SetUp]
        public void StartBrowserChrome()
        {
            webDriver = new ChromeDriver
            {
                Url = "https://www.expedia.com/"
            };
        }

        [Test]
        public void CheckAge()
        {
            DateTime dateAndTime = DateTime.Now;
            var today = dateAndTime.ToString("MM/dd/yyyy");

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='package-origin-hp-package']"));
            var origin = webDriver.FindElement(By.XPath("//*[@id='package-origin-hp-package']"));
            origin.SendKeys("Sydney");

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='package-destination-hp-package']"));
            var destination = webDriver.FindElement(By.XPath("//*[@id='package-destination-hp-package']"));
            destination.SendKeys("Gold Coast");

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='package-departing-hp-package']"));
            var departing = webDriver.FindElement(By.XPath("//*[@id='package-departing-hp-package']"));
            departing.SendKeys(today);

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='package-returning-hp-package']"));
            var returning = webDriver.FindElement(By.XPath("//*[@id='package-returning-hp-package']"));
            returning.SendKeys(today);

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='traveler-selector-hp-package']/div/ul/li/button"));
            var travelers = webDriver.FindElement(By.XPath("//*[@id='traveler-selector-hp-package']/div/ul/li/button"));
            travelers.Click();

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='traveler-selector-hp-package']/div/ul/li/div/div/div[1]/div[3]/div[1]/div[4]/button"));
            var childrenAdd = webDriver.FindElement(By.XPath("//*[@id='traveler-selector-hp-package']/div/ul/li/div/div/div[1]/div[3]/div[1]/div[4]/button"));
            childrenAdd.Click();

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='search-button-hp-package']"));
            var sumbitBtn = webDriver.FindElement(By.XPath("//*[@id='search-button-hp-package']"));
            sumbitBtn.Click();

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='gcw-packages-form-hp-package']/div[2]/div/ul/li/a"));
            var errorMessage = webDriver.FindElement(By.XPath("//*[@id='gcw-packages-form-hp-package']/div[2]/div/ul/li/a"));
            var isErrorMessageCorrect = errorMessage.Text.Equals("Please provide the ages of children below.");
            Assert.IsTrue(isErrorMessageCorrect);
        }

        [Test]
        public void MoreThanSixPessengers()
        {
            DateTime dateAndTime = DateTime.Now;
            var today = dateAndTime.ToString("MM/dd/yyyy");

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='package-origin-hp-package']"));
            var origin = webDriver.FindElement(By.XPath("//*[@id='package-origin-hp-package']"));
            origin.SendKeys("Sydney");

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='package-destination-hp-package']"));
            var destination = webDriver.FindElement(By.XPath("//*[@id='package-destination-hp-package']"));
            destination.SendKeys("Gold Coast");

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='package-departing-hp-package']"));
            var departing = webDriver.FindElement(By.XPath("//*[@id='package-departing-hp-package']"));
            departing.SendKeys(today);

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='package-returning-hp-package']"));
            var returning = webDriver.FindElement(By.XPath("//*[@id='package-returning-hp-package']"));
            returning.SendKeys(today);

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='traveler-selector-hp-package']/div/ul/li/button"));
            var travelers = webDriver.FindElement(By.XPath("//*[@id='traveler-selector-hp-package']/div/ul/li/button"));
            travelers.Click();
            
            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='traveler-selector-hp-package']/div/ul/li/div/div/div[1]/div[2]/div[4]/button"));
            var adultsAdd = webDriver.FindElement(By.XPath("//*[@id='traveler-selector-hp-package']/div/ul/li/div/div/div[1]/div[2]/div[4]/button"));

            for (int i = 1; i < 5;i++)
            {
                adultsAdd.Click();
            }
         
        

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='traveler-selector-hp-package']/div/ul/li/div/div/div[1]/div[3]/div[1]/div[4]/button"));
            var childrenAdd = webDriver.FindElement(By.XPath("//*[@id='traveler-selector-hp-package']/div/ul/li/div/div/div[1]/div[3]/div[1]/div[4]/button"));
            childrenAdd.Click();

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='search-button-hp-package']"));
            var sumbitBtn = webDriver.FindElement(By.XPath("//*[@id='search-button-hp-package']"));
            sumbitBtn.Click();

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='gcw-packages-form-hp-package']/div[2]/div/ul/li/a"));
            var errorMessage = webDriver.FindElement(By.XPath("//*[@id='gcw-packages-form-hp-package']/div[2]/div/ul/li/a"));
            var isErrorMessageCorrect = errorMessage.Text.Equals("We are only able to book between 1 and 6 travelers. Please adjust the number of travelers for your search.");
            Assert.IsTrue(isErrorMessageCorrect);
        }




        public static IWebElement WaitForElementToAppear(IWebDriver driver, int waitTime, By waitingElement)
        {
            IWebElement wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime)).Until(ExpectedConditions.ElementExists(waitingElement));
            return wait;
        }

        [TearDown]
        public void QuitDriver()
        {
            webDriver.Quit();
        }
    }
}