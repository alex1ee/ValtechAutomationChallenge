using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using TechTalk.SpecFlow;

namespace ValtechAutomationChallenge.SeleniumCommon
{
    public class WebDriverFactory
    {
        public static Action<string, IWebDriver> CustomWebDriverSetup;

        private const string DefaultLanguage = "en";

        public static IWebDriver CreateDriver(bool enableJavascript = true, bool ensureCleanSession = false, string language = DefaultLanguage)
        {
            //var browserConfiguration = (BrowserConfigurationSection)ConfigurationManager.GetSection("testExecutionSettings/browser");
            return CreateDriver("chrome", enableJavascript, ensureCleanSession, language);
        }

        private static IWebDriver CreateDriver(string browser, bool enableJavascript, bool ensureCleanSession, string language)
        {
            IWebDriver driver;
            if (!enableJavascript && browser.ToLower() != "firefox")
            {
                ScenarioContext.Current.Pending(); //only FF correctly supports turning off javascript
            }
            switch (browser.ToLower())
            {
                case "firefox":
                    var profile = new FirefoxProfile();
                    //profile.SetPreference("javascript.enabled", enableJavascript);
                    //profile.SetPreference("intl.accept_languages", language);
                    driver = new FirefoxDriver(profile);
                    break;
                case "ie":
                    var options = new InternetExplorerOptions();
                    options.EnsureCleanSession = ensureCleanSession;
                    driver = new InternetExplorerDriver("drivers", options);
                    if (!enableJavascript) throw new Exception("Cannot disable js with ie");
                    if (language != DefaultLanguage) throw new Exception("Cannot set non-English language with ie");
                    break;
                case "chrome":
                    var co = new ChromeOptions();
                    //co.AddArgument("--ignore-certificate-errors");
                    //co.AddArgument("--allow-no-sandbox-job");
                    //co.AddArgument("--lang=" + language);
                    //driver = new ChromeDriver("drivers", co);
                    driver = new ChromeDriver();
                    break;
                case "phantomjs":
                    driver = new PhantomJSDriver("drivers");
                    break;
                default:
                    throw new ArgumentException("Invalid browser specified");
            }

            if (CustomWebDriverSetup != null)
            {
                CustomWebDriverSetup(browser.ToLower(), driver);
            }

            driver.Manage().Window.Maximize();
            return driver;
        }

    }
}
