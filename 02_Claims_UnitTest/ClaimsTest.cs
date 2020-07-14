using System;
using System.Collections.Generic;
using _02_Claims_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Claims_UnitTest
{
    [TestClass]
    public class ClaimsTest
    {
        [TestMethod]
        public void GetListOfCLaims_Test()
        {
            //Arrange
            Claim newOne = new Claim();
            Claim_Repo repo = new Claim_Repo();
            repo.AddClaim(newOne);
            //ACT
            Queue<Claim> newList = repo.GetListOfClaims();
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
    }
}
