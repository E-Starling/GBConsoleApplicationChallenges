using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Repository
{
    public class Greeting_Repository
    {
        protected readonly List<Customer> _greetingDir = new List<Customer>();
        // Create
        public bool AddCustomerToDirectory(Customer cust)
        {
            int startingCount = _greetingDir.Count();
            _greetingDir.Add(cust);
            bool wasAdded = (_greetingDir.Count() > startingCount) ? true : false;
            return wasAdded;
        }
        // Read
        public List<Customer> GetCustomers()
        {
            return _greetingDir.OrderBy(g => g.LastName).ThenBy(g => g.FirstName).ToList();
        }
        public List<Customer> GetByLastName(string lastName)
        {
            return _greetingDir.Where(g => g.LastName == lastName).ToList();
        }
        public List<Customer> GetByType(CustomerType custType)
        {
            return _greetingDir.Where(g => g.CustType == custType).ToList();
        }
        public Customer GetCustById(int iD)
        {
            return _greetingDir.Where(g => g.ID == iD).SingleOrDefault();
        }
        // Delete
        public bool DeleteExistingCustomer(Customer existingCustomer)
        {
            bool deleteResult = _greetingDir.Remove(existingCustomer);
            return deleteResult;
        }
    }
}
