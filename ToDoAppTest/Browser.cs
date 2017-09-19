using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppTest
{
    public class Browser: IBrowser
    {
        private IWebDriver _webdriver;
        public IWebDriver GetChromeDriver()
        {
            var options = new ChromeOptions();
            string chromeDriverPath = @"C:\Users\Obozhko\source\repos\ToDoAppTest\packages\Selenium.Chrome.WebDriver.2.31\driver";
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("download.directory_upgrade", true);
            options.AddUserProfilePreference("safebrowsing.enabled", true);
            options.AddArgument("--disable-extensions");

            _webdriver = new ChromeDriver(chromeDriverPath, options);
            _webdriver.Manage().Window.Maximize();

            return _webdriver;

        }
    }
}
