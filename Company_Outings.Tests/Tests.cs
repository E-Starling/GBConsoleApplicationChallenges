using System;
using System.Collections.Generic;
using Company_Outings.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Company_Outings.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        //Adding an outing
        public void AddToMenuDir_ShouldBeTrue()
        {
            Outing outing = new Outing(EventType.Concert, 23, new DateTime(2023, 3, 2), 50);
            CO_Repository repo = new CO_Repository();
            bool addResult = repo.AddOutingToDirectory(outing);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        //Seeing if list of outings has the outing just added
        public void GetDirectly_ShouldReturnCurrentCollection()
        {
            Outing outing = new Outing(EventType.Concert, 23, new DateTime(2023, 3, 2), 50); 
            CO_Repository repo = new CO_Repository();
            repo.AddOutingToDirectory(outing);
            List<Outing> outings = repo.GetOutings();
            bool dirhasoutings = outings.Contains(outing);
            Assert.IsTrue(dirhasoutings);
        }
    }
}
