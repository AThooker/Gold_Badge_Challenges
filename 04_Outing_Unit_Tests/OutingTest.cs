using System;
using System.Collections.Generic;
using _04_CompanyClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04_Outing_Unit_Tests
{
    [TestClass]
    public class OutingTest
    {
        OutingRepo _repo = new OutingRepo();

        [TestMethod]
        public void AddToListTest()
        {
            //Arrange
            Outing golfEvent = new Outing();
            //ACT
            bool hasAdded = _repo.AddToList(golfEvent);
            //Assert
            Assert.IsTrue(hasAdded);
        }

        [TestMethod]
        public void GetListTest()
        {
            //Arrange
            Outing oneEvent = new Outing();
            _repo.AddToList(oneEvent);
            //Act
            List<Outing> returnList = _repo.GetListOfOutings();
            bool hasItem = returnList.Contains(oneEvent);
            //Assert
            Assert.IsTrue(hasItem);
        }
    }
}
