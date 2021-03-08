using _06_GreenPlan_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _06_GreenPlan_UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            List<Car> _listOfCars = new List<Car>();
            Car car = new Car();
            GreenPlanRepo _repo = new GreenPlanRepo();
        }
        [TestMethod]
        public void TestAddMethod()
        {

        }
    }
}

