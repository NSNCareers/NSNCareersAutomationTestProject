using CoreFramework.Config;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.Threading;
using static CoreFramework.Enumerations.Enums;

namespace CoreFramework.BrowserConfig
{
    internal class BrowserSession
    {
        private static ThreadLocal<IWebDriver> _threadDriver = new ThreadLocal<IWebDriver>();
        private static readonly object _lock = new object();
        private static string browserType = Browser.localhost.ToString();

        static BrowserSession()
        {
        }

        public static IWebDriver OpenBrowser()
        {
            lock (_lock)
            {
                _threadDriver.Value = InitBrowser.InitializeDriver(browserType);
                return _threadDriver.Value;
            }
        }

        public static IWebDriver driver
        {
            get { return _threadDriver.Value; }
        }
        
        public static void GoToDesiredUrl()
        {
            string Url = JsonConfig.GetJsonValue("BaseUrl");
            try
            {
                var driver = _threadDriver.Value;
                driver.Navigate().GoToUrl(Url);
            }
            catch (Exception e)
            {
            }
        }

        public static void KillBrowser2()
        {
            Process myProcess = new Process();

            try
            {
                myProcess.StartInfo.UseShellExecute = false;
                // You can start any process, HelloWorld is a do-nothing example.  
                myProcess.StartInfo.FileName = "BrowserConfig/killBrowser.sh";
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.Start();
                // This code assumes the process you are starting will terminate itself.   
                // Given that is is started without a window so you cannot terminate it   
                // on the desktop, it must terminate itself or you can do it programmatically  
                // from this application using the Kill method. 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void KillBrowser()
        {
            Process[] AllProcesses = Process.GetProcesses();
            foreach (var process in AllProcesses)
            {
                if (process.MainWindowTitle != "")
                {
                    string s = process.ProcessName.ToLower();
                    if (s == "iexplore" || s == "iexplorer" || s == "" || s == "firefox")
                        process.Kill();
                }
            }
        }
       
        public static void QuitBrowser()
        {

            if (_threadDriver.Value != null)
            {
                //_threadDriver.Value.Close();
                _threadDriver.Value.Quit();
            }
        }
    }
}
