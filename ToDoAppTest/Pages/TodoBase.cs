using OpenQA.Selenium;
using System.Collections.Generic;
using ToDoAppTest.Helpers;

namespace ToDoAppTest.Pages
{
    public class TodoBase
    {
        #region Fields
        private IWebDriver _driver;
        private readonly string URL = @"http://todomvc.com/examples/angularjs/#/";

        private By _addListItemField => By.Id("new-todo");
        private By _toogleAllItemsButton => By.Id("toggle-all");       
        #endregion Fields

        #region Constructors
        public TodoBase(IWebDriver driver)
        {
            _driver = driver;
            _driver.Navigate().GoToUrl(URL);
        }
        #endregion Constructors

        #region Elements    
        public IWebElement AddListItemInput => _driver.WaitForVisible(_addListItemField);
        public IWebElement ToogleAllItemsButton => _driver.WaitForClickable(_toogleAllItemsButton);
        public ToDoList ListItems => new ToDoList(_driver);

        #endregion Elements

        public void AddToDoItem(string itemName)
        {
            AddListItemInput.SendKeys(itemName);
            AddListItemInput.SendKeys(Keys.Enter);
        }

            
        public void AddSeveralToDoItems(List<string> itemList)
        {
            itemList.ForEach(x => AddToDoItem(x));
        }


    }

}
