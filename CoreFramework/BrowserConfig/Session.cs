using OpenQA.Selenium;

namespace CoreFramework.BrowserConfig
{
    public static class Session
    {

       public static void StartBrowser()
        {
            BrowserSession.OpenBrowser();
            BrowserSession.GoToDesiredUrl();
        }

        public static void CloseBrowser()
        {
            BrowserSession.QuitBrowser();
            BrowserSession.KillBrowser();
            BrowserSession.KillBrowser2();
        }

        public static IWebDriver Driver
        {
            get { return BrowserSession.driver; }
        }
    }
}
