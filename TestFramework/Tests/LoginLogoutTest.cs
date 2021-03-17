using CoreFramework.BrowserConfig;
using NUnit.Framework;
using PageObjectFramework.Interfaces;
using PageObjectFramework.IOC;
using PageObjectFramework.Pages;
using PageObjectFramework.Pages.Interfaces;
using PageObjectFramework.StartUpConfig;

namespace TestFramework.Tests
{
    [TestFixture()]
    [Parallelizable]
    public class LoginLogoutTest : StartUpClass
    {
        private IHomePage _homePage;
        private ILoginPage _loginPage;
        private IUserAccountPage _userAccountPage;
        private ILogoutPage _logoutPage;

        [OneTimeSetUp]
        public void SetUp()
        {
            _homePage = UnityWrapper.Resolve<IHomePage>();

            _loginPage = _homePage.ClickOnLoginLink<LoginPage>();

            var email = "nsntestaccount@yahoo.com";
            var password = "Password01$";
            _loginPage.EnterEmail(email);
            _loginPage.EnterPassword(password);
            _loginPage.CheckRememberMeRadioButton();
            _userAccountPage = _loginPage.ClickOnlogInButton<UserAccountPage>();
        }

        [OneTimeTearDown]
        public void Teardown()
        {
        }



        [Test, Category("Login logout User")]
        public void AssertPageTitel()
        {
            var titel = _userAccountPage.GetPageTitel();
            var pageTitel = "Home pages - LoginApp";
            Assert.AreEqual(titel,pageTitel);
        }

        [Test, Category("Login logout User")]
        public void ClickOnUserEmail()
        {
            
           _userAccountPage.ClickOnUserEmail();
        }

        [Test, Category("Login logout User")]
        public void LogUserOut()
        {
            _logoutPage = _userAccountPage.ClickOnLogoutButton<LogoutPage>();
            var titel = _logoutPage.GetPageTitel();
            var pageTitel = "Logs out - LoginApp";
            Assert.AreEqual(titel, pageTitel);
        }

        [Test, Category("Login logout User")]
        public void LogUserOutAndVerifyTextOnLogoutPage()
        {
            var text = "You have successfully logged out.";
            var boolResults = _logoutPage.VerifyLogoutText(text);
            Assert.IsTrue(boolResults,"Element does not contain text");
        }

        [Test, Category("Login logout User")]
        public void NavigateBackToHomePage()
        {
            _homePage = _logoutPage.ClickOnLoginAppLink<HomePage>();
            var titel = _homePage.GetPageTitel();
            var pageTitel = "Home pages - LoginApp";
            Assert.AreEqual(titel, pageTitel);
        }
    }
}
