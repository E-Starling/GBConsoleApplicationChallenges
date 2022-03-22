using System;
using System.Collections.Generic;
using Cafe.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cafe.Tests
{
    [TestClass]
    public class Tests
    {
        private Menu _item;
        private MenuRepository _repo;
        [TestInitialize]
        //Setting up some items
        public void Setup()
        {
            _repo = new MenuRepository();
            _item = new Menu(2, "Komododouble", "Double cheeseburger with medium fries and medium drink", "Lettace, Tomato, Onion, Ketchup, Mustard, Cheese", 5.99);
            _repo.AddMenuItemToDirectory(_item);
            

        }
        [TestMethod]
        //Adding an item
        public void AddToMenuDir_ShouldBeTrue()
        {
            Menu item = new Menu(5, "Komodosingle", "Single cheeseburger and fries", "Lettace, Onion, Ketchup, Mustard, Cheese", 2.99);
            MenuRepository repo = new MenuRepository();
            bool addResult = repo.AddMenuItemToDirectory(item);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        //Seeing if list of items has the item just added
        public void GetDirectly_ShouldReturnCurrentCollection()
        {
            Menu item = new Menu(5, "Komodosingle", "Single cheeseburger and fries", "Lettace, Onion, Ketchup, Mustard, Cheese", 2.99);
            MenuRepository repo = new MenuRepository();
            repo.AddMenuItemToDirectory(item);
            List<Menu> items = repo.GetItems();
            bool dirhasitems = items.Contains(item);
            Assert.IsTrue(dirhasitems);
        }
        [TestMethod]
        //Searching items in dir by menuNumber
        public void GetItemByMenuNum_ShouldReturnTrue()
        {
            Menu searchMenuNum = _repo.GetMenuItemByNum(2);
            Assert.AreEqual(_item, searchMenuNum);
        }
        [TestMethod]
        //Searching items in dir by menuName
        public void GetItemByItemName_ShouldReturnTrue()
        {
            Menu searchMenuName = _repo.GetMenuItemByName("Komododouble");
            Assert.AreEqual(_item, searchMenuName);
        }
        [TestMethod]
        //Deleting existing MenuItem in Dir
        public void DeleteExisitingMenuItem_ShouldReturnTrue()
        {
            Menu item = _repo.GetMenuItemByNum(2);
            bool removeItem = _repo.DeleteExistingMenuItem(item);
            Assert.IsTrue(removeItem);
        }
    }
}
