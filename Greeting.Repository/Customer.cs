using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Repository
{
    public enum CustomerType { Potential, Current, Past }
    public class Customer
    {
        public Customer() { }
        public Customer(string firstName, string lastName, CustomerType custType)
        {
            FirstName = firstName;
            LastName = lastName;
            CustType = custType;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType CustType { get; set; }     
    }
}
