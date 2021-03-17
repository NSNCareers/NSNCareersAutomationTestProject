using CoreFramework.BrowserConfig;
using NUnit.Framework;
using PageObjectFramework.Interfaces;
using PageObjectFramework.IOC;
using PageObjectFramework.Pages;
using PageObjectFramework.Pages.Interfaces;
using PageObjectFramework.StartUpConfig;
using System;

namespace TestFramework.Tests
{
    [TestFixture()]
    [Parallelizable]
    public class RegisterNewUserTest : StartUpClass
    {
        private IHomePage _homePage;
        private IRegisterPage _registerPage;
        private IRegisterConfirmationPage _registerConfirmationPage;
        private Random _random;


        [OneTimeSetUp]
        public void SetUp()
        {
            _homePage = UnityWrapper.Resolve<IHomePage>();

            _random = new Random();
            var value = _random.Next(1,20000);
            _registerPage = _homePage.ClickOnRegisterLink<RegisterPage>();
            
            var email = $"nsntestaccount{value}@yahoo.com";
            var password = "Password01$";
            _registerPage.EnterEmail(email);
            _registerPage.EnterPassword(password);
            _registerPage.EnterConfirmPassword(password);
            _registerConfirmationPage = _registerPage.ClickOnSubmitButton<RegisterConfirmationPage>();
            
        }



        [Test, Category("Register a new User")]
        public void AssertPageTitel()
        {
            var titel = _registerConfirmationPage.GetPageTitel();
            var pageTitel = "Register confirmationing - LoginApp";
            Assert.AreEqual(titel,pageTitel);
        }

        [Test, Category("Register a new User")]
        public void AssertEmailMessage()
        {
            var emailText = "Please check your email to confirm your account.";
            var boolResults = _registerConfirmationPage.VerifyEmailText(emailText);
            Assert.True(boolResults,"Confirm email message was not displayed");
        }

        [Test, Category("Register a new User")]
        public void AssertRegisterButtonDisplayed()
        {
            var locator = "a[href*='Register']";
            var boolResults = _homePage.VerifyElementDisplayed(locator);
            Assert.IsTrue(boolResults, $"Register button is not displayed");
        }

        [Test, Category("Register a new User")]
        public void AssertLoginButtonDisplayed()
        {
            var locator = "a[href*='Login']";
            var boolResults = _homePage.VerifyElementDisplayed(locator);
            Assert.IsTrue(boolResults, $"Login button is not displayed");
        }

        [Test, Category("Register a new User")]
        public void AssertUserNavigatesBackToHomePage()
        {
            _homePage = _registerConfirmationPage.ClickOnLoginAppLink<HomePage>();
            var titel = _homePage.GetPageTitel();
            var pageTitel = "Home pages - LoginApp";
            Assert.AreEqual(titel, pageTitel);
        }
    }
}
