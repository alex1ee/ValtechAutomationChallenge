using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using ValtechAutomationChallenge.SeleniumCommon;

namespace ValtechAutomationChallenge
{
    [Binding]
    public class StepsContext
    {
        private static IWebDriver _driver;
        private static string _mainWindowHandle;

        public static string ErrorScreenshotDirectory;
        public static bool DisableJavascript { get; set; }
        public static bool JavaScriptIsDisabled;
        public static TimeSpan DefaultImplicitWait = TimeSpan.FromSeconds(8);
        private static bool _newSession;

        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    InitDriver();
                }
                return _driver;
            }

            set
            {
                if (_driver != null)
                {
                    _driver.Close();
                    _driver.Dispose();
                }

                _driver = value;
            }
        }

        static StepsContext()
        {
            Console.WriteLine("Gone into StepsContext.StepsContext static method");
        }

        private static void InitDriver()
        {
            if (_driver != null)
            {
                _driver.Close();
                _driver.Dispose();
            }
            _driver = WebDriverFactory.CreateDriver(true, _newSession);
            _driver.Manage().Timeouts().ImplicitlyWait(DefaultImplicitWait);
            _mainWindowHandle = _driver.CurrentWindowHandle;
        }

        [AfterTestRun]
        [AfterFeature]
        public static void AfterTestRun()
        {
            var nativeDriverQuit = Task.Factory.StartNew(() => Driver.Quit());
            if (!nativeDriverQuit.Wait(TimeSpan.FromSeconds(10)))
            {
                //CleanUpProcessByInheritance();
                Driver.Close();
                Driver.Dispose();
            }
        }

        //private static void CleanUpProcessByInheritance()
        //{
        //    var currentProcessPid = Process.GetCurrentProcess().Id;
        //    foreach (var process in Process.GetProcesses())
        //    {
        //        using (
        //            var mo =
        //                new ManagementObject("win32_process.handle='" +
        //                                     process.Id.ToString(CultureInfo.InvariantCulture) + "'"))
        //        {
        //            mo.Get();
        //            var parentPid = Convert.ToInt32(mo["ParentProcessId"]);

        //            if (parentPid == currentProcessPid)
        //            {
        //                process.Kill();
        //            }
        //        }
        //    }
        //}
    }
}
