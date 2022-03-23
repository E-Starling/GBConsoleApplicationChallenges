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
            return _greetingDir;
        }
        public List<Customer> GetByLastName(string lName)
        {
            return _greetingDir.Where(g => g.LastName == lName).ToList();
        }
        public List<Customer> GetByType(CustomerType type)
        {
            return _greetingDir.Where(g => g.CustType == type).ToList();
        }
        // Delete
        public bool DeleteExistingCustomer(Customer existingCustomer)
        {
            bool deleteResult = _greetingDir.Remove(existingCustomer);
            return deleteResult;
        }
    }
}
