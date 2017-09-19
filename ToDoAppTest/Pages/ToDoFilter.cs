using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAppTest.Helpers;

namespace ToDoAppTest.Pages
{
    public enum FilterOptions
    {
        All,
        Active,
        Completed
    }

    public class ToDoFilter
    {
        #region Fields
        private IWebDriver _driver;
        private By _filterPane = By.Id("filters");
        private By _filterButtons = By.XPath("./li/a");
        private By _clearButton = By.Id("clear-completed");
        #endregion Fields

        #region Constructors
        public ToDoFilter(IWebDriver driver)
        {
            _driver = driver;
            _driver.WaitForVisible(_filterPane);
            
        }
        #endregion Constructors

        #region Elements
        public List<IWebElement> FilterList => _driver.FindElement(_filterPane).FindElements(_filterButtons).ToList();
        public IWebElement ClearAllItemsButton => _driver.WaitForClickable(_clearButton);
        #endregion Elements

        public void FilterToDoList(FilterOptions option)
        {
            FilterList[(int)option].Click();
            _driver.WaitAjax();
        }

        public void ClearAllItems()
        {
            ClearAllItemsButton.Click();
            _driver.WaitAjax();
        }
    }
}
