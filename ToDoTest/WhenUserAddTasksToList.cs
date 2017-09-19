
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using ToDoAppTest;
using ToDoAppTest.Pages;

namespace ToDoTest
{
    [TestFixture]
    public class WhenUserAddTasksToList
    {
        #region Fields
        private IWebDriver _driver;
        private TodoBase _toDoPage;
        #endregion Fields

        #region SetUp and TearDown
        [SetUp]
        public void StartTest()
        {
            Browser browser = new Browser();
            _driver = browser.GetChromeDriver();
            _toDoPage = new TodoBase(_driver);
        }

        [TearDown]
        public void EndTest()
        {
            _driver.Quit();
        }
        #endregion SetUp and TearDown

        #region Tets
        [TestCase("some item")]
        public void TaskShouldBeDisplayedInList(string itemName)
        {
            _toDoPage.AddToDoItem(itemName);
            ToDoList list = new ToDoList(_driver);

            Assert.NotNull(list.GetListItemsByName(itemName), "Item is not found in list");            
        }

        [TestCase("ite ot destroy")]
        public void TaskShouldBeDestroyedWhenUserClickDestroyButton(string itemName)
        {
            _toDoPage.AddToDoItem(itemName);
            ToDoList list = new ToDoList(_driver);
            list.DestroyItemsByName(itemName);

            Assert.Null(list.GetListItemsByName(itemName), "Not all items were destroyed");

        }
        
        [Test]
        public void AllTasksShouldBeDeletedWhenUserClearAll( )
        {
            _toDoPage.AddSeveralToDoItems(new List<string> { "item1","item2","item2"});
            ToDoFilter filter = new ToDoFilter(_driver);
            filter.ClearAllItems();

            ToDoList list = new ToDoList(_driver);
            Assert.Null(list.listItems, "Not all items were destroyed");
        }
        #endregion Test
    }
}
