using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAppTest.Helpers;

namespace ToDoAppTest.Pages
{
    public class ToDoList
    {
        #region Fields
        private IWebDriver _driver;
        private By _list => By.Id("todo-list");
        private By _listItem => By.XPath("//ul[@id='todo-list']/li");
        private By _toogleCheckBox = By.XPath("//input[@type='checkbox']");
        private By _destroyButton = By.ClassName("destroy");       

        #endregion Fields

        #region Constructors
        public ToDoList(IWebDriver driver)
        {
            _driver = driver;
            _driver.WaitForVisible(_list);
        }
        #endregion Constructors

        #region Elements
        public IEnumerable<IWebElement> listItems
        {
            get
            {
                return _driver.FindElements(_listItem);
            }
        }
        #endregion Elements

        # region Public 
        public List<IWebElement>  GetListItemsByName(string itemName)
        {
            var foundItems = from item in listItems
                            where item.Text.Equals(itemName)
                            select item;
            return foundItems.ToList();
        }
        

        public void ToogleItemsByName(string itemName)
        {
            GetListItemsByName(itemName)
                .ForEach(x => x.FindElement(_toogleCheckBox).Click());          
        }

        public void DestroyItemsByName(string itemName)
        {
            foreach (IWebElement item in GetListItemsByName(itemName))
            {
                new Actions(_driver).MoveToElement(item).Perform();
                item.FindElement(_destroyButton).Click();
            }
        }
        #endregion Public
    }
}
