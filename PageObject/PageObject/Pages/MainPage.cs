using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace PageObject.Pages
{
    class MainPage
    {


        private readonly IWebDriver driver;

        public IWebElement originInput => GetElement("//*[@id='package-origin-hp-package']");
        public IWebElement destinationInput => GetElement("//*[@id='package-destination-hp-package']");
        public IWebElement departingInput => GetElement("//*[@id='package-departing-hp-package']");
        public IWebElement retutningInput => GetElement("//*[@id='package-returning-hp-package']");
        public IWebElement travelersInput => GetElement("//*[@id='traveler-selector-hp-package']/div/ul/li/button");
        public IWebElement addChildren => GetElement("//*[@id='traveler-selector-hp-package']/div/ul/li/div/div/div[1]/div[3]/div[1]/div[4]/button");
        public IWebElement addAdults => GetElement("//*[@id='traveler-selector-hp-package']/div/ul/li/div/div/div[1]/div[2]/div[4]/button");
        public IWebElement submitBtn => GetElement("//*[@id='search-button-hp-package']");
        public string errorMessage => GetText("//*[@id='gcw-packages-form-hp-package']/div[2]/div/ul/li/a");

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetText(string xPath)
        {
            WaitForElementToAppear(driver, 15, By.XPath(xPath));

            return driver.FindElement(By.XPath(xPath)).Text;
        }

        public static IWebElement WaitForElementToAppear(IWebDriver driver, int waitTime, By waitingElement)
        {
            IWebElement wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime)).Until(ExpectedConditions.ElementExists(waitingElement));
            return wait;
        }

        public IWebElement GetElement(string xPath)
        {
            WaitForElementToAppear(driver, 15, By.XPath(xPath));

            return driver.FindElement(By.XPath(xPath));
        }

    }
}
