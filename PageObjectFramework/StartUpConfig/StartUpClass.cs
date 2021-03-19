using CoreFramework.BrowserConfig;
using CoreFramework.Reporting;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using PageObjectFramework.Interfaces;
using PageObjectFramework.IOC;
using PageObjectFramework.Pages.Interfaces;
using System;

namespace PageObjectFramework.StartUpConfig
{
    [TestFixture]
    [Parallelizable]
    public class StartUpClass
    {
        public ExtentReportsHelper extent;

        public StartUpClass()
        {
        }

        [OneTimeSetUp]
        public void StartUp()
        {
            extent = new ExtentReportsHelper();
            extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ResolveDependency.RegisterAndResolveDependencies();
            Session.StartBrowser();
            extent.SetStepStatusPass("Successfully opened browser session");
        }


        [OneTimeTearDown]
        public void Teardown()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = TestContext.CurrentContext.Result.StackTrace;
                var errorMessage = "<pre>" + TestContext.CurrentContext.Result.Message + "</pre>";
                switch (status)
                {
                    case TestStatus.Failed:
                        extent.SetTestStatusFail("Failed",$"<br>{errorMessage}<br>Stack Trace: <br>{stacktrace}<br>");
                        break;
                    case TestStatus.Skipped:
                        extent.SetTestStatusSkipped();
                        break;
                    default:
                        extent.SetTestStatusPass();
                        break;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                Session.CloseBrowser();
                extent.SetStepStatusPass("Successfully closed browser");
            }
        }

        #region Interfacce declarations

        public readonly IHomePage homePage;
        public readonly IRegisterPage searchPage;
        public readonly ILoginPage loginPage;
        public readonly ILogoutPage logoutPage;
        public readonly IRegisterConfirmationPage registerConfirmationPage;
        public readonly IUserAccountPage userAccountPage;

        #endregion
    }
}
