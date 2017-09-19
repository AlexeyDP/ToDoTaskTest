using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppTest.Helpers
{
    public static class WaitHelper
    {
        public static IWebElement WaitForClickable(this IWebDriver webdriver, By elementSelector, int timeout = 3)
        {
            IWebElement elem;
            WebDriverWait wait = new WebDriverWait(webdriver, TimeSpan.FromSeconds(timeout));

            return elem = wait.Until(ExpectedConditions.ElementToBeClickable(elementSelector));
        }

        public static IWebElement WaitForVisible(this IWebDriver webdriver, By elementSelector, int timeout = 3)
        {
            IWebElement elem;
            WebDriverWait wait = new WebDriverWait(webdriver, TimeSpan.FromSeconds(timeout));

            return elem = wait.Until(ExpectedConditions.ElementIsVisible(elementSelector));
        }
        public static void WaitAjax(this IWebDriver webDriver)
        {
            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)webDriver;
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(delegate (IWebDriver d) { return (bool)(jsExec).ExecuteScript("return (typeof($) === 'undefined') ? true : !$.active;"); });
        }
    }
}
