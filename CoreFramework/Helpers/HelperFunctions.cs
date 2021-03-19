using CoreFramework.Reporting;
using OpenQA.Selenium;
using System;

namespace CoreFramework.Helpers
{
    public class HelperFunctions
    {
        public static void HighLighterMethod(IWebDriver driver, By by)
        {
            try
            {
                var element = driver.FindElement(by);
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].setAttribute('style', 'background: blue; border: 3px solid blue;');", element);
 
            }
            catch (Exception e)
            {
            }
        }

        public static string ScreenCaptureAsBase64String(IWebDriver driver)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            return screenshot.AsBase64EncodedString;
        }
    }
}

