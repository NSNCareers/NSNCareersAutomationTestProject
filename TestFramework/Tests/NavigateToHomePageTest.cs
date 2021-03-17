using NUnit.Framework;
using PageObjectFramework.Interfaces;
using PageObjectFramework.IOC;
using PageObjectFramework.StartUpConfig;

namespace TestFramework.Tests
{
    [TestFixture()]
    [Parallelizable]
    public class NavigateToHomePageTest : StartUpClass
    {
        private IHomePage _homePage;

        [OneTimeSetUp]
        public void SetUp()
        {
            _homePage = UnityWrapper.Resolve<IHomePage>();
        }


        [Test, Category("Navigate to Home Page")]
        public void AssertPageTitel()
        {
            var titel = _homePage.GetPageTitel();
            var pageTitel = "Home pages - LoginApp";
            Assert.AreEqual(titel,pageTitel);
        }

        [Test, Category("Navigate to Home Page")]
        public void AssertRegisterButtonDisplayed()
        {
            var locator = "a[href*='Register']";
            var boolResults = _homePage.VerifyElementDisplayed(locator);
            Assert.IsTrue(boolResults,$"Register button is not displayed");
        }

        [Test, Category("Navigate to Home Page")]
        public void AssertLoginButtonDisplayed()
        {
            var locator = "a[href*='Login']";
            var boolResults = _homePage.VerifyElementDisplayed(locator);
            Assert.IsTrue(boolResults, $"Login button is not displayed");
        }

        [Test, Category("Navigate to Home Page")]
        public void AssertWelcomeTextDisplayed()
        {
            var locator = "h1[class='display-4']";
            var boolResults = _homePage.VerifyElementDisplayed(locator);
            Assert.IsTrue(boolResults, $"Welcome message is not displayed");
        }
    }
}
