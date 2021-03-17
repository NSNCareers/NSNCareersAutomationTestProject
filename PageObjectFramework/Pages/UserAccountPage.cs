using CoreFramework.BaseClasses;
using OpenQA.Selenium;
using PageObjectFramework.Pages.Interfaces;

namespace PageObjectFramework.Pages
{
    public class UserAccountPage : BaseClass, IUserAccountPage
    {
        private static string pageName = "UserAccountPage";
        private static By locator = By.CssSelector("button[type='submit']");

        public UserAccountPage() : base(pageName, locator)
        {
        }


        public string GetPageTitel()
        {
            var titel = driver.Title;

            return titel;
        }

        public bool VerifyElementDisplayed(string selector)
        {
            var locator = By.CssSelector(selector);
            var boolResults = IsElementDisplayed(locator);
            return boolResults;
        }

        public T ClickOnLogoutButton<T>() where T : class
        {
            var locator = By.CssSelector("button[type='submit']");
            ClickOnElement(locator);
            return GetPage<T>();
        }

        public T ClickOnLoginLink<T>() where T : class
        {
            var locator = By.CssSelector("a[class*='navbar-brand']");
            ClickOnElement(locator);
            return GetPage<T>();
        }

        public void ClickOnUserEmail()
        {
            var locator = By.CssSelector("a[title='Manage']");
            ClickOnElement(locator);
        }

        public void EnterTelephoneNumber(string number)
        {
            var locator = By.CssSelector("input[type='tel']");
            EnterText(locator,number);
        }

        public void ClickOnSaveButton()
        {
            var locator = By.CssSelector("button[id='update-profile-button']");
            ClickOnElement(locator);
        }

        public void EnterNewEmail(string newEmail)
        {
            var locator = By.CssSelector("input[type='email']");
            EnterText(locator, newEmail);
        }

        public void ClickOnChangeEmailButton()
        {
            var locator = By.CssSelector("button[id='change-email-button']");
            ClickOnElement(locator);
        }

        public void ClickEmailButton()
        {
            var locator = By.CssSelector("li>a[id='email']");
            ClickOnElement(locator);
        }

        public void ClickPersonalDataButton()
        {
            var locator = By.CssSelector("li>a[id='personal-data']");
            ClickOnElement(locator);
        }

        public void ClickDownloadButton()
        {
            var locator = By.CssSelector("form>button[class='btn btn-primary']");
            ClickOnElement(locator);
        }

        public bool VerifyManageEmailText(string emailText)
        {
            var locator = By.CssSelector("div[role='alert']");
            var boolResults = DoesElementContainText(locator, emailText);
            return boolResults;
        }

        public bool VerifyWarningMessage(string emailText)
        {
            var locator = By.CssSelector("p>strong");
            var boolResults = DoesElementContainText(locator, emailText);
            return boolResults;
        }

        public bool VerifyProfileText(string profileText)
        {
            var locator = By.CssSelector("div[role='alert']");
            var boolResults = DoesElementContainText(locator, profileText);
            return boolResults;
        }
    }
}
