using CoreFramework.BrowserConfig;
using OpenQA.Selenium;
using System;

namespace CoreFramework.BaseClasses
{
    public abstract partial class BaseClass
    {
        private readonly string _pageName;
        private readonly By _by;

        public BaseClass(string pageName,By by)
        {
            _pageName = pageName;
            _by = by;
            this.OnPage();
        }

        private bool OnPage()
        {
            WaitUntillPageFullyLoaded();
            var boolResults = WaitTillElementIsDisplayed(_by);
            if (!boolResults)
            {
                Console.WriteLine($"Unable to find element on page {_pageName}");
                return false;
            }
            return true;
        }

        public static IWebDriver driver
        {
            get { return BrowserSession.driver; }
        }

        public T GetPage<T>()
        {

            return (T)Activator.CreateInstance(typeof(T), new object[] { });
        }
    }
}
