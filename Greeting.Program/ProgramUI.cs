using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greeting.Repository;

namespace Greeting.Program
{
    public class ProgramUI
    {
        private Greeting_Repository _repo = new Greeting_Repository();
        public void Run()
        {
            SeedContent();
            Menu();
        }
        private void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the option you would like:\n" +
                    "1. Display\n" +
                    "2. Search\n" +
                    "3. Add Customer\n" +
                    "4. Modify\n" +
                    "5. Remove\n" +
                    "6. Exit");
                string user = Console.ReadLine();
                switch (user)
                {
                    case "1":
                        Display();
                        break;
                    case "2":
                        Search();
                        break;
                    case "3":
                        Add();
                        break;
                    case "4":
                        Modify();
                        break;
                    case "5":
                        Remove();
                        break;
                    case "6":
                    case "e":
                    case "exit":
                        continueToRun = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid number from 1 to 6.");
                        Console.ForegroundColor = ConsoleColor.White;
                        AnyKey();
                        break;
                }
            }
        }
        // Create
        private void Add()
        {
            bool anotherone = true;
            while (anotherone)
            {
                Console.Clear();
                Customer cust = new Customer();
                // FirstName
                Console.Write("Please enter a first name: ");
                cust.FirstName = Console.ReadLine();
                // LastName
                Console.Write("Please enter a last name: ");
                cust.LastName = Console.ReadLine();
                // CustomerType
                bool custType = true;
                while (custType)
                {
                    Console.WriteLine("Please state the type of customer: ");
                    Console.WriteLine("1. Potential\n" +
                            "2. Current\n" +
                            "3. Past");
                    string user = Console.ReadLine();
                    switch (user)
                    {
                        case "1":
                            cust.CustType = CustomerType.Potential;
                            custType = false;
                            break;
                        case "2":
                            cust.CustType = CustomerType.Current;
                            custType = false;
                            break;
                        case "3":
                            cust.CustType = CustomerType.Past;
                            custType = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please select a valid number from 1 to 3.");
                            Console.ForegroundColor = ConsoleColor.White;
                            AnyKey();
                            break;
                    }
                }
                // ID
                bool checkingiD = true;
                while (checkingiD)
                {
                    Console.Write("Please enter an ID for the customer: ");
                    int iD;
                    string user = Console.ReadLine();
                    if (!int.TryParse(user, out iD))
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid id!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        var existing = _repo.GetCustById(int.Parse(user));
                        if (existing == null)
                        {
                            cust.ID = int.Parse(user);
                            checkingiD = false;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("That ID is taken");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }       
                _repo.AddCustomerToDirectory(cust);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Customer was successfully added!");
                Console.ForegroundColor = ConsoleColor.White;
                // Adding Multiple Devs
                Console.WriteLine("Would you like to add another customer?");
                Console.WriteLine("1. yes\n" +
                    "2. no");
                string userinput = Console.ReadLine();
                switch (userinput)
                {
                    case "1":
                    case "yes":
                    case "y":
                        Console.Clear();
                        break;
                    case "2":
                    case "no":
                    case "n":
                        anotherone = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter either yes or no.");
                        Console.ForegroundColor = ConsoleColor.White;
                        AnyKey();
                        break;
                }
            }
        }
        // Read
        private void Display()
        {
            bool displaymenu = true;
            while (displaymenu)
            {
                Console.Clear();
                Console.WriteLine("1. Show all customers\n" +
                        "2. Show all potential customers\n" +
                        "3. Show all past customers\n" +
                        "4. Show all current customers\n" +
                        "5. Back");
                string user = Console.ReadLine();
                switch (user)
                {
                    case "1":
                        DisplayCustomers();
                        break;
                    case "2":
                        DisplayPotential();
                        break;
                    case "3":
                        DisplayPast();
                        break;
                    case "4":
                        DisplayCurrent();
                        break;
                    case "5":
                        //Go back
                        displaymenu = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid number from 1 to 5.");
                        Console.ForegroundColor = ConsoleColor.White;
                        AnyKey();
                        break;
                }
            }
        }
        private void DisplayCustomers()
        {
            Console.Clear();
            Console.WriteLine("FirstName        LastName        Type        ID        Email");
            List<Customer> listofCusts = _repo.GetCustomers();
            foreach (Customer cust in listofCusts)
            {
                DisplayCustomer(cust);
            }
            AnyKey();
        }
        private void DisplayCustomer(Customer customer)
        {
            
            if (customer.CustType == CustomerType.Potential)
            {
                string email = "We currently have the lowest rates on Helicopter Insurance!";
                Console.WriteLine($"{customer.FirstName}        {customer.LastName}         {customer.CustType}         {customer.ID}         {email}");
                Console.WriteLine("");
            }
            else if (customer.CustType == CustomerType.Current)
            {
                string email = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                Console.WriteLine($"{customer.FirstName}        {customer.LastName}         {customer.CustType}         {customer.ID}         {email}");
                Console.WriteLine("");
            }
            else
            {
                string email = "It's been a long time since we've heard from you, we want you back.";
                Console.WriteLine($"{customer.FirstName}        {customer.LastName}         {customer.CustType}         {customer.ID}         {email}");
                Console.WriteLine("");
            }        
        }
        private void DisplayPotential()
        {
            Console.Clear();
            Console.WriteLine("FirstName        LastName        Type        ID        Email");
            List<Customer> listofCusts = _repo.GetByType(CustomerType.Potential);
            foreach (Customer cust in listofCusts)
            {
                DisplayCustomer(cust);
            }
            AnyKey();
        }
        private void DisplayPast()
        {
            Console.Clear();
            Console.WriteLine("FirstName        LastName        Type        ID        Email");
            List<Customer> listofCusts = _repo.GetByType(CustomerType.Past);
            foreach (Customer cust in listofCusts)
            {
                DisplayCustomer(cust);
            }
            AnyKey();
        }
        private void DisplayCurrent()
        {
            Console.Clear();
            Console.WriteLine("FirstName        LastName        Type        ID        Email");
            List<Customer> listofCusts = _repo.GetByType(CustomerType.Current);
            foreach (Customer cust in listofCusts)
            {
                DisplayCustomer(cust);
            }
            AnyKey();
        }
        private void Search()
        {
            bool searchMenu = true;
            while (searchMenu)
            {
                Console.Clear();
                Console.WriteLine("1. By LastName\n" +
                        "2. By ID\n" +
                        "3. Back\n");
                string user = Console.ReadLine();
                switch (user)
                {
                    case "1":

                        SearchCustomerByLName();
                        break;
                    case "2":
                        SearchCustomerByID();
                        break;
                    case "3":
                        //Go back
                        searchMenu = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid number from 1 to 3.");
                        Console.ForegroundColor = ConsoleColor.White;
                        AnyKey();
                        break;
                }
            }
        }
        private void SearchCustomerByLName()
        {
            Console.Clear();
            Console.Write("Please enter a last name of a customer: ");
            string user = Console.ReadLine();
            List<Customer> listofCusts = _repo.GetByLastName(user);
                foreach (Customer cust in listofCusts)
                {
                    DisplayCustomer(cust);    
                }
            AnyKey();
        }
        private void SearchCustomerByID()
        {
            Console.Clear();
            bool search = true;
            while (search)
            {
                Console.Write("Please enter an ID of a customer you want to search for: ");
                int iD;
                string user = Console.ReadLine();
                if (!int.TryParse(user, out iD))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a number!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    int idSearch = int.Parse(user);
                    Customer cust = _repo.GetCustById(idSearch);
                    if (cust != null)
                    {
                        DisplayCustomer(cust);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Couldn't find developer by that ID");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    search = false;
                    AnyKey();
                }
            }
        }
        // Update
        private void Modify()
        {
            Console.Clear();
            bool moding = true;
            while (moding)
            {
                Console.Write("Please enter an ID of a Customer you want to modify: ");
                int iD;
                string user = Console.ReadLine();
                if (!int.TryParse(user, out iD))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a number!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    moding = false;
                    int idSearch = int.Parse(user);
                    Customer oldCust = _repo.GetCustById(idSearch);
                    if (oldCust != null)
                    {

                        DisplayCustomer(oldCust);
                        // Mod FirstName
                        Console.Write("Please enter a first name: ");
                        oldCust.FirstName = Console.ReadLine();
                        // Mod LastName
                        Console.Write("Please enter a last name: ");
                        oldCust.LastName = Console.ReadLine();
                        // Mod CustomerType
                        bool custType = true;
                        while (custType)
                        {
                            Console.WriteLine("Please state the type of customer: ");
                            Console.WriteLine("1. Potential\n" +
                                    "2. Current\n" +
                                    "3. Past");
                            string input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    oldCust.CustType = CustomerType.Potential;
                                    custType = false;
                                    break;
                                case "2":
                                    oldCust.CustType = CustomerType.Current;
                                    custType = false;
                                    break;
                                case "3":
                                    oldCust.CustType = CustomerType.Past;
                                    custType = false;
                                    break;
                                default:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Please select a valid number from 1 to 3.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    AnyKey();
                                    break;
                            }
                        }
                        // ID
                        bool yesorno = true;
                        while (yesorno)
                        {
                            Console.WriteLine("Do you want to change the ID?:\n" +
                                "1. yes\n" +
                                "2. no");
                            string userentry = Console.ReadLine();
                            switch (userentry)
                            {
                                case "1":
                                case "yes":
                                case "y":
                                    bool checkinganother = true;
                                    while (checkinganother)
                                    {
                                        Console.Write("Please enter an new ID for the customer: ");
                                        int I;
                                        string read = Console.ReadLine();
                                        if (!int.TryParse(read, out I))
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Please enter a valid id!");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            return;
                                        }
                                        else
                                        {
                                            var existing = _repo.GetCustById(int.Parse(read));
                                            if (existing == null)
                                            {
                                                oldCust.ID= int.Parse(read);
                                                checkinganother = false;
                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("That ID is taken");
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }
                                        }
                                    }
                                    yesorno = false;
                                    break;
                                case "2":
                                case "no":
                                case "n":
                                    yesorno = false;
                                    break;
                                default:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Please enter either yes or no.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    AnyKey();
                                    break;
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Customer was successfully updated!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Couldn't find developer by that ID");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                AnyKey();
            }
        }
        // Delete
        private void Remove()
        {
            Console.Clear();
            bool removing = true;
            while (removing)
            {
                Console.Write("Please enter the ID of the customer you wish to remove: ");
                int ID;
                string user = Console.ReadLine();
                if (!int.TryParse(user, out ID))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid id!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    int idSearch = int.Parse(user);
                    Customer cust = _repo.GetCustById(idSearch);
                    if (cust != null)
                    {
                        _repo.DeleteExistingCustomer(cust);
                        Console.WriteLine("Developer was deleted!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Couldn't find developer by that ID");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                        removing = false;
                }
            }
            AnyKey();
        }
        private void SeedContent()
        // adding in some customers
        {
            Customer bob = new Customer("Bob", "Smith", CustomerType.Potential, 33);
            Customer sue = new Customer("Sue", "Smith", CustomerType.Current, 55);
            Customer link = new Customer("Link", "Past", CustomerType.Past, 1991);
            Customer mario = new Customer("Mario", "Mario", CustomerType.Potential, 59);
            Customer zelda = new Customer("Zelda", "Notlink", CustomerType.Past, 1990);
            _repo.AddCustomerToDirectory(bob);
            _repo.AddCustomerToDirectory(sue);
            _repo.AddCustomerToDirectory(link);
            _repo.AddCustomerToDirectory(mario);
            _repo.AddCustomerToDirectory(zelda);
        }
        private void AnyKey()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any key to continue...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}
