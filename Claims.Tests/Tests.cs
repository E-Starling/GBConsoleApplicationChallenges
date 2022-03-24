using System;
using System.Collections.Generic;
using Claims.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Claims.Tests
{
    [TestClass]
    public class Tests
    {
        private Claim _claim;
        private ClaimsRepo _repo;
        [TestInitialize]
        //Setting up a claim
        public void Setup()
        {
            _repo = new ClaimsRepo();
            _claim = new Claim(1,ClaimType.Car, "Car accident on 420.", 512, new DateTime(2020,4,25), new DateTime(2020,4,28), true);
            _repo.AddClaimToDirectory(_claim);
        }
        [TestMethod]
        //Adding a Claim
        public void AddClaimToDir_ShouldBeTrue()
        {
            Claim homeclaim = new Claim(2, ClaimType.Home, "Home accident.", 2000, new DateTime(2021, 5, 4), new DateTime(2022, 3, 1), false);
            bool addResult = _repo.AddClaimToDirectory(homeclaim);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        //Seeing if list of claims has the claim just added
        public void GetDirectly_ShouldReturnCorrentCollection()
        {
            Claim homeclaim = new Claim(2, ClaimType.Home, "Home accident.", 2000, new DateTime(2021, 5, 4), new DateTime(2022, 3, 1), false);
            _repo.AddClaimToDirectory(homeclaim);
            List<Claim> claims = _repo.GetClaims();
            bool dirhasclaims = claims.Contains(homeclaim);
            Assert.IsTrue(dirhasclaims);
        }
        [TestMethod]
        //Deleting exiting Claim in Dir
        public void DeleteExistingClaim_ShouldReturnTrue()
        {
            Claim claim = _repo.GetClaimById(1);
            bool removeClaim = _repo.DeleteExistingClaim(claim);
            Assert.IsTrue(removeClaim);
        }
    }
}
