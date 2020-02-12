using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using GitHubAutomation.Models;

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


        public IWebElement ageCheckBox => GetElement("//*[@for='chk-age']");
        public IWebElement submitBtn => GetElement("//*[@name='btn-submit']");
        public IWebElement returnPlaceCheckBox => GetElement("//*[@id='locations-wrapper']/div[1]");
        public IWebElement logInBtn => GetElement("//*[@id='primnav--acct']/li[2]/a");
        public IWebElement submitLogInBtn => GetElement("//*[@id='account_login_button']");
        public IWebElement ageInput => GetElement("//*[@id='ae-search']/div[3]/div[5]/input[2]");
        public IWebElement emailInput => GetElement("//*[@id='member_username']");
        public IWebElement passwordInput => GetElement("//*[@id='member_password']");
        public string logInErrorMessage => GetText("//*[@id='member-response-left']");
        public string errorMessage => GetText("//*[@class='ui-warn-flag-title']");

        public MainPage FillInPickUpFields(Location location)
        {
            selectItem("//*[@value='" + location.Country + "']");
            selectItem("//*[@id='" + location.City + "']");
            selectItem("//*[@id='" + location.Place + "']");
            return this;
        }

        public MainPage InsertValueInAgeInput(string value)
        {
            ageInput.SendKeys(value);
            return this;
        }

        public MainPage InsertValueInEmailInput(string value)
        {
            emailInput.SendKeys(value);
            return this;
        }

        public MainPage InsertValueInPasswordInput(string value)
        {
            passwordInput.SendKeys(value);
            return this;
        }

        public MainPage ClickOnLogInBtn()
        {
            logInBtn.Click();
            return this;
        }

        public MainPage ClickOnSubmitLogInBtn()
        {
            submitLogInBtn.Click();
            return this;
        }

        public void selectItem(string path)
        {
            WaitForElementToAppear(driver, 15, By.XPath(path));
            var element = driver.FindElement(By.XPath(path));
            element.Click();
        }

        public MainPage clickOnAgeCheckBox()
        {
            ageCheckBox.Click();
            return this;
        }

        public MainPage clickOnReturnPlaceCheckBox()
        {
            returnPlaceCheckBox.Click();
            return this;
        }

        public MainPage SubmitInformation()
        {
            submitBtn.Click();
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