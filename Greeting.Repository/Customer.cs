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
        public Customer(string firstName, string lastName, CustomerType custType, int iD)
        {
            FirstName = firstName;
            LastName = lastName;
            CustType = custType;
            ID = iD;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType CustType { get; set; }     
        public int ID { get; set; }

    }
}
