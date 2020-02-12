using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using GitHubAutomation.Driver;
using GitHubAutomation.Pages;
using GitHubAutomation.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.Extensions;

namespace GitHubAutomation.Tests
{
    [TestFixture]
    public class WebTests : GeneralConfig
    {
        [Test]
        public void CheckAge()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                MainPage mainPage = new MainPage(Driver)
                    .FillInPickUpFields(CreatingOrder.PickUpFields())
                    .clickOnAgeCheckBox()
                    .SubmitInformation();

                Assert.AreEqual("ВОЗРАСТ ВОДИТЕЛЯ", mainPage.errorMessage);
            });
        }

        [Test]
        public void RentCarWithEmptyReturnFields()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                MainPage mainPage = new MainPage(Driver)
                    .FillInPickUpFields(CreatingOrder.PickUpFields())
                    .clickOnReturnPlaceCheckBox()
                    .SubmitInformation();

                Assert.AreEqual("НЕ ОСТАВЛЯЙТЕ ПОЛЯ ДЛЯ ЗАПОЛНЕНИЯ ПУСТЫМИ", mainPage.errorMessage);
            });
        }

        [Test]
        public void RentCarWithEmptyPickUpFields()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                MainPage mainPage = new MainPage(Driver)
                    .SubmitInformation();
                Assert.AreEqual("НЕ ОСТАВЛЯЙТЕ ПОЛЯ ДЛЯ ЗАПОЛНЕНИЯ ПУСТЫМИ", mainPage.errorMessage);
            });
        }

        [Test]
        public void SetOneHundredFiftyYearOld()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                MainPage mainPage = new MainPage(Driver)
                    .FillInPickUpFields(CreatingOrder.PickUpFields())
                    .clickOnAgeCheckBox()
                    .InsertValueInAgeInput("150")
                    .SubmitInformation();
                Assert.AreEqual("НЕ КОРРЕКТНЫЙ ВОЗРАСТ", mainPage.errorMessage);
            });
        }

        [Test]
        public void SetThreeYearOld()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                MainPage mainPage = new MainPage(Driver)
                    .FillInPickUpFields(CreatingOrder.PickUpFields())
                    .clickOnAgeCheckBox()
                    .InsertValueInAgeInput("3")
                    .SubmitInformation();
                Assert.AreEqual("НЕ КОРРЕКТНЫЙ ВОЗРАСТ", mainPage.errorMessage);
            });
        }
        
        [Test]
        public void LogInWithEmptyFields()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                MainPage mainPage = new MainPage(Driver)
                    .ClickOnLogInBtn()
                    .ClickOnSubmitLogInBtn();
                Assert.AreEqual("ПОЖАЛУЙСТА, ВВЕДИТЕ ВЕРНЫЙ АДРЕС ЭЛ.ПОЧТЫ И ПАРОЛЬ.", mainPage.logInErrorMessage);
            });
        }

        [Test]
        public void LogInWithIncorrectEmail()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                MainPage mainPage = new MainPage(Driver)
                    .ClickOnLogInBtn()
                    .InsertValueInEmailInput(CreatingUser.IncorrectUser().Email)
                    .InsertValueInPasswordInput(CreatingUser.TestUser().Password)
                    .ClickOnSubmitLogInBtn();
                Assert.AreEqual("ПОЖАЛУЙСТА, ВВЕДИТЕ ВЕРНЫЙ АДРЕС ЭЛ.ПОЧТЫ И ПАРОЛЬ.", mainPage.logInErrorMessage);
            });
        }

        [Test]
        public void LogInWithEmptyEmail()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                MainPage mainPage = new MainPage(Driver)
                    .ClickOnLogInBtn()
                    .InsertValueInPasswordInput(CreatingUser.TestUser().Password)
                    .ClickOnSubmitLogInBtn();
                Assert.AreEqual("ПОЖАЛУЙСТА, ВВЕДИТЕ ВЕРНЫЙ АДРЕС ЭЛ.ПОЧТЫ И ПАРОЛЬ.", mainPage.logInErrorMessage);
            });
        }

        [Test]
        public void LogInWithEmptyPassword()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                MainPage mainPage = new MainPage(Driver)
                    .ClickOnLogInBtn()
                    .InsertValueInEmailInput(CreatingUser.TestUser().Email)
                    .ClickOnSubmitLogInBtn();
                Assert.AreEqual("ПОЖАЛУЙСТА, ВВЕДИТЕ ВЕРНЫЙ АДРЕС ЭЛ.ПОЧТЫ И ПАРОЛЬ.", mainPage.logInErrorMessage);
            });
        }

        [Test]
        public void LogInWithIncorrectPassword()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                MainPage mainPage = new MainPage(Driver)
                    .ClickOnLogInBtn()
                    .InsertValueInEmailInput(CreatingUser.TestUser().Email)
                    .InsertValueInPasswordInput(CreatingUser.IncorrectUser().Email)
                    .ClickOnSubmitLogInBtn();
                Assert.AreEqual("ПОЖАЛУЙСТА, ВВЕДИТЕ ВЕРНЫЙ АДРЕС ЭЛ.ПОЧТЫ И ПАРОЛЬ.", mainPage.logInErrorMessage);
            });
        }
    }
}