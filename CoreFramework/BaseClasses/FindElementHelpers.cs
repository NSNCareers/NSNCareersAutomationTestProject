using System;
using System.Collections.Generic;
using CoreFramework.Helpers;
using OpenQA.Selenium;

namespace CoreFramework.BaseClasses
{
    public abstract partial class BaseClass
    {
        private void ScrollToView(By by)
        {
            IWebElement element = driver.FindElement(by);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public IWebElement GetElementOrThrow(By by)
        {
            try
            {
                var elementLocated = driver.FindElement(by);
                HelperFunctions.HighLighterMethod(driver, by);
                return elementLocated;
            }
            catch (Exception)
            {
                var elementLocated = driver.FindElement(by);
                HelperFunctions.HighLighterMethod(driver, by);
                ScrollToView(elementLocated);
                return elementLocated;
            }
        }

        public IEnumerable<IWebElement> GetElementsOrThrow(By by)
        {
            try
            {
                var elementLocated = driver.FindElements(by);
                HelperFunctions.HighLighterMethod(driver, by);
                return elementLocated;
            }
            catch (Exception)
            {
                var elementLocated = driver.FindElements(by);
                HelperFunctions.HighLighterMethod(driver, by);
                ScrollToView(elementLocated[0]);
                return elementLocated;
            }
        }

        public bool IsElementDisplayed(By by)
        {
            try
            {
                var elementLocated = driver.FindElement(by);
                HelperFunctions.HighLighterMethod(driver,by);
                return elementLocated.Displayed;
            }
            catch (Exception)
            {
                var elementLocated = driver.FindElement(by);
                HelperFunctions.HighLighterMethod(driver, by);
                ScrollToView(elementLocated);
                return elementLocated.Displayed;
            }
        }

        public bool DoesElementContainText(By by,string text)
        {
            try
            {
                var elementLocated = driver.FindElement(by);
                HelperFunctions.HighLighterMethod(driver, by);
                var getText = elementLocated.Text;
                return getText == text;
            }
            catch (Exception)
            {
                var elementLocated = driver.FindElement(by);
                HelperFunctions.HighLighterMethod(driver, by);
                ScrollToView(elementLocated);
                return elementLocated.Text == text;
            }
        }
    }
}
