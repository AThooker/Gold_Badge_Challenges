using System;
using System.Collections.Generic;
using _03_Badge_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Badges_UnitTest
{
    [TestClass]
    public class Badge_UnitTest
    {
        [TestMethod]
        public void AddBadges_Test()
        {
            //Arrange
            Badge_Repository _repo = new Badge_Repository();
            Dictionary<int, List<string>> test = new Dictionary<int, List<string>>();
            List<string> testList = new List<string>();
            //Act
            bool confirmAdd = _repo.AddToDictionary(1, testList);
            //Assert
            Assert.IsTrue(confirmAdd);
        }
        [TestMethod]
        public void GetList_Test()
        {
            //Arrange
            Badge_Repository _repo = new Badge_Repository();
            List<string> testList = new List<string>();
            _repo.AddToDictionary(1, testList);
            //Act
            Dictionary<int, List<string>> dict = _repo.GetList();
            bool confirmHas = dict.ContainsKey(1);
            bool confirmValue = dict.ContainsValue(testList);
            //Assert
            Assert.IsTrue(confirmHas);
            Assert.IsTrue(confirmValue);
        }
        [TestMethod]
        public void GetDoorByID_Test()
        {
            //Arrange
            Badge_Repository _repo = new Badge_Repository();
            List<string> testList = new List<string>();
            testList.Add("list");
            _repo.AddToDictionary(1, testList);
            //Act
            List<string> testListTwo = _repo.GetDoorByID(1);
            bool confirm = testListTwo.Contains("list");
            //Assert
            Assert.IsTrue(confirm);
        }
        [TestMethod]
        public void DeleteAllDoors_Test()
        {
            //Arrange
            Badge_Repository _repo = new Badge_Repository();
            List<string> testList = new List<string>();
            testList.Add("list");
            _repo.AddToDictionary(1, testList);
            //Act
            bool testValue = _repo.DeleteDoorValues(1);
            //Assert
            Assert.IsTrue(testValue);

        }
    }
}
