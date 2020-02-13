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
        public string signInErrorMessage => GetText(" //*[@id='gss-signin-incorrect-email-or-password']/text()");
        public string signInEmailErrorMessage => GetText("//*[@id='signInEmailErrorMessage']");
        public string signInPasswordErrorMessage => GetText("//*[@id='signInPasswordErrorMessage']");
        public string errorMessage => GetText("//*[@class='ui-warn-flag-title']");
       
        public MainPage FillInPickUpFields(Order location)
        {
            selectItem("//*[@value='" + location.Country + "']");
            selectItem("//*[@id='" + location.City + "']");
            selectItem("//*[@id='" + location.Place + "']");
            return this;
        }


       
        public MainPage InsertValueInEmailInput(string value)
        {
           

            emailInput.Click();
            emailInput.SendKeys(value);
            return this;
        }

        public MainPage InsertValueInPasswordInput(string value)
        {
        
            passwordInput.Click();
            passwordInput.SendKeys(value);
            return this;
        }

        public MainPage ClickOnSignInBtn()
        {
          
            signInBtn.Click();
            return this;
        }

        public MainPage ClickOnAccountBtn()
        {

            accountBtn.Click();
            return this;
        }


        public MainPage ClickOnSubmitLogInBtn()
        {
            selectItem("//*[@id='gss-signin-submit']");
            submitLogInBtn.Click();
            return this;
        }

        public void selectItem(string path)
        {
            
            WaitForElementToAppear(driver, 15, By.XPath(path));
            var element = driver.FindElement(By.XPath(path));
            element.Click();
        }

        public MainPage Wait(IWebDriver webDriver)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(2000));
            return this;
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