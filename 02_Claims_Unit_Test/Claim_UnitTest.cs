using System;
using System.Collections.Generic;
using _02_Claims_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Claims_Unit_Test
{
    [TestClass]
    public class Claim_UnitTest
    {
        [TestMethod]
        public void GetListOfCLaims_Test()
        {
            //Arrange
            Claim newOne = new Claim();
            Claim_Repo repo = new Claim_Repo();
            repo.AddClaim(newOne);
            //ACT
            List<Claim> newList = repo.GetListOfClaims();
            bool hasClaim = newList.Contains(newOne);
            //ASSERT
            Assert.IsTrue(hasClaim);

        }
        [TestMethod]
        public void AddToList_Test()
        {
            //ARRANGE
            Claim newOne = new Claim();
            Claim_Repo repo = new Claim_Repo();

            //ACT
            bool addClaim = repo.AddClaim(newOne);

            //ASSERT
            Assert.IsTrue(addClaim);
        }

        private readonly Claim search;
        [TestMethod]
        public void GetClaimByID_Test()
        {
            //ARRANGE
            Claim_Repo repo = new Claim_Repo();
            //ACT
            Claim newClaim = repo.GetClaimByID(1);
            //ASSERT
            Assert.AreEqual(search, newClaim);
        }
    }
}
