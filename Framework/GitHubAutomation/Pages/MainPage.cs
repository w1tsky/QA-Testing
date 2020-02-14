using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using GitHubAutomation.Models;
using NUnit.Framework;
using System.Threading;

namespace GitHubAutomation.Pages
{
    public class MainPage
    {
        IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }
        
        public IWebElement searchBtn => GetElement("//*[@id='search-button-hp-package']");
        public IWebElement accountBtn => GetElement("//*[@id='account-menu']");
        public IWebElement signInBtn => GetElement("//*[@id='account-signin']");
        public IWebElement submitLogInBtn => GetElement("//*[@id='gss-signin-submit']");
        public IWebElement emailInput => GetElement("//*[@id='login-form-email-label']");
        public IWebElement passwordInput => GetElement("//*[@id='gss-signin-password']");
        public IWebElement originInput => GetElement("//*[@id='package-origin-hp-package']");
        public IWebElement destinationInput => GetElement("//*[@id='package-destination-hp-package']");
        public IWebElement departingTimeInput => GetElement("//*[@id='package-departing-hp-package']");
        public IWebElement returningTimeInput => GetElement("//*[@id='package-returning-hp-package']");
        public IWebElement travelersCountInput => GetElement("//*[@id='traveler-selector-hp-package']/div/ul/li/button");
        public IWebElement addChildrenBtn => GetElement("//*[@id='traveler-selector-hp-package']/div/ul/li/div/div/div[1]/div[3]/div[1]/div[4]/button");
        public string signInErrorMessage => GetText(" //*[@id='gss-signin-incorrect-email-or-password']/text()");
        public string signInEmailErrorMessage => GetText("//*[@id='signInEmailErrorMessage']");
        public string signInPasswordErrorMessage => GetText("//*[@id='signInPasswordErrorMessage']");
        public string errorMessage => GetText("//*[@id='gcw-packages-form-hp-package']/div[2]/div/ul/li/a");
       


        public MainPage AddChildren()
        {
            Wait(driver, 3, By.XPath("//*[@id='traveler-selector-hp-package']/div/ul/li/button"));
            travelersCountInput.Click();
            Wait(driver, 3, By.XPath("//*[@id='traveler-selector-hp-package']/div/ul/li/div/div/div[1]/div[3]/div[1]/div[4]/button"));
            addChildrenBtn.Click();
            return this;
        }

       

        public MainPage ClickOnSignInBtn()
        {
            Wait(driver, 3, By.XPath("//*[@id='account-signin']"));
            signInBtn.Click();
            return this;
        }




        public MainPage InsertValueInEmailInput(string value)
        {
            Wait(driver, 3, By.XPath("//*[@id='login-form-email-label']"));
            emailInput.Click();
            emailInput.SendKeys(value);
            return this;
        }
        
        public MainPage InsertValueInPasswordInput(string value)
        {
            Wait(driver, 3, By.XPath("//*[@id='gss-signin-password']"));
            passwordInput.Click();
            passwordInput.SendKeys(value);
            return this;
        }


        public MainPage ClickOnAccountBtn()
        {
            Wait(driver, 3, By.XPath("//*[@id='account-menu']"));
            accountBtn.Click();
            return this;
        }


        public MainPage ClickOnSubmitLogInBtn()
        {
            Wait(driver, 5, By.XPath("//*[@id='gss-signin-submit']"));
            submitLogInBtn.Click();
            return this;
        }


        public MainPage InsertOrderValue(Order order)
        {
            
            originInput.SendKeys(order.Origin);
            Wait(driver, 5, By.XPath("//*[@id='package-destination-hp-package']"));
            destinationInput.SendKeys(order.Destination);
            Wait(driver, 5, By.XPath("//*[@id='package-destination-hp-package']"));
            departingTimeInput.SendKeys(order.DepartingTime);
            Wait(driver, 5, By.XPath("//*[@id='package-returning-hp-package']"));
            returningTimeInput.SendKeys(order.ReturningTime);
            return this;
        }

   
        public void selectItem(string path)
        {
            
            WaitForElementToAppear(driver, 15, By.XPath(path));
            var element = driver.FindElement(By.XPath(path));
            element.Click();
        }



        public WebDriverWait Wait(IWebDriver driver, int timeout, By element)
        {
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(timeout));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(element));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
            return wait;
        }

      
       

        public MainPage SubmitInformation()
        {
            searchBtn.Click();
            return this;
        }

        public static IWebElement WaitForElementToAppear(IWebDriver driver, int waitTime, By waitingElement)
        {
          
            IWebElement wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime)).Until(ExpectedConditions.ElementExists(waitingElement));
            return wait;
        }

        public string GetText(string xPath)
        {
            WaitForElementToAppear(driver, 15, By.XPath(xPath));

            return driver.FindElement(By.XPath(xPath)).Text;
        }

        public IWebElement GetElement(string xPath)
        {
            WaitForElementToAppear(driver, 15, By.XPath(xPath));

            return driver.FindElement(By.XPath(xPath));
        }
    }
}