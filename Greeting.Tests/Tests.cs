using System;
using System.Collections.Generic;
using Greeting.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Greeting.Tests
{
    [TestClass]
    public class Tests
    {
        private Customer _cust;
        private Greeting_Repository _repo;
        [TestInitialize]
        //Setting up a customer
        public void Setup()
        {
            _repo = new Greeting_Repository();
            _cust = new Customer("Bob", "Smith", CustomerType.Current, 123);
            _repo.AddCustomerToDirectory(_cust);
        }
        [TestMethod]
        //Adding a Customer
        public void AddCustToDir_ShouldBeTrue()
        {
            Customer bobby = new Customer("Bobby", "Kotick", CustomerType.Potential, 420);
            bool addResult = _repo.AddCustomerToDirectory(bobby);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        //Seeing if list of customers has the customer just added
        public void GetDirectly_ShouldReturnCorrentCollection()
        {
            Customer thad = new Customer("Thad", "Thud", CustomerType.Past, 97);
            _repo.AddCustomerToDirectory(thad);
            List<Customer> custs = _repo.GetCustomers();
            bool dirhascusts = custs.Contains(thad);
            Assert.IsTrue(dirhascusts);
        }
        [TestMethod]
        //Searching customer in dir by Last Name
        public void GetCustomerByLName_ShouldReturnTrue()
        {
            List<Customer> lName = _repo.GetByLastName("Smith");
            bool dirhassmith = lName.Contains(_cust);
            Assert.IsTrue(dirhassmith);
        }
        [TestMethod]
        //Searching customer in dir by CustomerType
        public void GetCustsByCustType_ShouldReturnTrue()
        {
            List<Customer> potential = _repo.GetByType(CustomerType.Current);
            bool dirhaspotential= potential.Contains(_cust);
            Assert.IsTrue(dirhaspotential);
        }
        [TestMethod]
        //Searching customer in dir by ID
        public void GetCustById_ShouldReturnTrue()
        {
            Customer searchID = _repo.GetCustById(123);
            Assert.AreEqual(_cust, searchID);
        }
        [TestMethod]
        //Deleting exiting Customer in Dir
        public void DeleteExistingCust_ShouldReturnTrue()
        {
            Customer cust = _repo.GetCustById(123);
            bool removeCust = _repo.DeleteExistingCustomer(cust);
            Assert.IsTrue(removeCust);
        }
    }
}
