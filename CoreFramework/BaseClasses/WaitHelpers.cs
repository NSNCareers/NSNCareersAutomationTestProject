using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CoreFramework.BaseClasses
{
     public abstract partial class BaseClass
    {

        public bool WaitTillElementSelected(By by, int timeout = 20)
        {
            var boolResults = false;

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            try
            {
                boolResults = wait.Until(x => x.FindElement(by).Selected);
            }
            catch (Exception e)
            {
            }

            return boolResults;
        }

        public bool WaitTillElementEnabled(By by, int timeout = 20)
        {
            var boolResults = false;

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            try
            {
                boolResults= wait.Until(x => x.FindElement(by).Enabled);
            }
            catch (Exception e)
            {
            }

            return boolResults;
        }

        public bool WaitTillElementContainsString(By by, string text, int timeout = 20)
        {
            var boolResults = false;

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            try
            {
                boolResults = wait.Until(x => x.FindElement(by).Text == text);
            }
            catch (Exception e)
            {
            }

            return boolResults;
        }

        public bool WaitTillElementIsDisplayed(By by, int timeout = 20)
        {
            var boolResults = false;

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            try
            {
                boolResults = wait.Until(x => x.FindElement(by).Displayed);
            }
            catch (Exception e)
            {
            }

            return boolResults;
        }

        public bool WaitUntillPageFullyLoaded(int timeout = 20)
        {
            var boolResults = false;
            string page = "Page not loaded";
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            try
            {
                wait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
            }
            catch (Exception e)
            {
            }

            return boolResults;
        }

        public void ExecuteJavaScript(string executionText, object obj)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(executionText,obj);
        }
    }
}
