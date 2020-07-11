using System;
using System.Collections.Generic;
using System.Linq;
using _01_Cafe_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Cafe_Unit_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddItemsTest()
        {
            //Arrange ----> setting what is needed for our method to work
            CafeRepo newRepo = new CafeRepo();
            MenuItem item = new MenuItem();

            //ACT --> call the method
            bool result = newRepo.AddMenuItem(item);

            //Assert
            Assert.IsTrue(result);

        }
        [TestMethod]
        public void GetList_Test()
        {
            //Arrange
            MenuItem item = new MenuItem();
            CafeRepo newRepo = new CafeRepo();
            newRepo.AddMenuItem(item);

            //ACT
            List<MenuItem> items = newRepo.GetList();

            bool hasItems = items.Contains(item);

            //Assert
            Assert.IsTrue(hasItems);
        }
        
        [TestMethod]
        
        public void RemoveItem_Test()
        {
            //Arrange what is needed for method to work
            CafeRepo _cafeRepo = new CafeRepo();
            List<MenuItem> items = _cafeRepo.GetList();
            MenuItem item = new MenuItem();

            //ACT ---> Call Method
            _cafeRepo.AddMenuItem(item);
            bool remove = _cafeRepo.DeleteExistingItem(item);
            bool doesHaveItem = items.Contains(item);

            //ASSERT
            Assert.IsFalse(doesHaveItem);
        }

        
    }
}
