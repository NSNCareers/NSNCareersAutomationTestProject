using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFramework.Helpers
{
    public class HelperFunctions
    {
        public static void HighLighterMethod(IWebDriver driver, By by)
        {
            var element = driver.FindElement(by);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].setAttribute('style', 'background: blue; border: 3px solid blue;');", element);
        }
    }
}

