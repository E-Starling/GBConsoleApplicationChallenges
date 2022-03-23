using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company_Outings.Repository;

namespace Company_Outings.Program
{
    public class ProgramUI
    {
        private CO_Repository _repo = new CO_Repository();
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
                    "2. Add Outing\n" +
                    "3. Exit");
                string user = Console.ReadLine();
                switch (user)
                {
                    case "1":
                        Display();
                        break;
                    case "2":
                        AddOuting();
                        break;
                    case "3":
                    case "e":
                    case "exit":
                        continueToRun = false;
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
        //Create
        private void AddOuting()
        {
            bool anotherone = true;
            while (anotherone)
            {
                Console.Clear();
                Outing outing = new Outing();
                //EventType events,int numPeople, DateTime date, double personCost, double eventCost
                // EventType
                bool checkingEventType = true;
                while (checkingEventType)
                {
                    Console.WriteLine("Please pick an event type type for the outing:\n" +
                        "1. Golf\n" +
                        "2. Bowling\n" +
                        "3. Amusement Park\n" +
                        "4. Concert");
                    string user = Console.ReadLine();
                    switch (user)
                    {
                        case "1":
                            outing.Events = EventType.Golf;
                            checkingEventType = false;
                            break;
                        case "2":
                            outing.Events = EventType.Bowling;
                            checkingEventType = false;
                            break;
                        case "3":
                            outing.Events = EventType.Amusement_Park;
                            checkingEventType = false;
                            break;
                        case "4":
                            outing.Events = EventType.Concert;
                            checkingEventType = false;
                            break;
                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please enter a valid number from 1 to 4.\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                // Number of people
                bool checkingPeopleNum = true;
                while (checkingPeopleNum)
                {
                    Console.Write("Please enter the number of people for the event: ");
                    int peopleNum;
                    string user = Console.ReadLine();
                    if (!int.TryParse(user, out peopleNum))
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a number!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                            outing.NumPeople = int.Parse(user);
                            checkingPeopleNum = false;     
                    }
                }
                // Date of the Event
                bool checkingDate = true;
                while (checkingDate)
                {
                    Console.Write("Please enter in a date for the event (YYYY,MM,DD): ");
                    DateTime date;
                    string user = Console.ReadLine();                   
                    if (!DateTime.TryParse(user, out date))
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter in a date!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        outing.Date = DateTime.Parse(user);
                        checkingDate = false;
                    }
                }
                // Person Cost
                bool checkingPersonCost = true;
                while (checkingPersonCost)
                {
                    Console.Write("Please enter the cost per person for the event: ");
                    double personCost;
                    string user = Console.ReadLine();
                    if (!double.TryParse(user, out personCost))
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a number!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        outing.PersonCost = double.Parse(user);
                        checkingPersonCost = false;
                    }
                }
                // Event Cost
                bool checkingEventCost = true;
                while (checkingEventCost)
                {
                    Console.Write("Please enter the total cost for the event: ");
                    double eventCost;
                    string user = Console.ReadLine();
                    if (!double.TryParse(user, out eventCost))
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a number!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        outing.EventCost = double.Parse(user);
                        checkingEventCost = false;
                    }
                }
               
                _repo.AddOutingToDirectory(outing);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Outing was successfuly added!");
                Console.ForegroundColor = ConsoleColor.White;
                // Adding Multiple Meals
                Console.WriteLine("Would you like to add another outing?");
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
        //Read
        private void Display()
        {
            bool displayMenu = true;
            while (displayMenu)
            {
                Console.Clear();
                Console.WriteLine("1. Display Outings\n" +
                        "2. Display out by event type\n" +
                        "3. Back\n");
                string user = Console.ReadLine();
                switch (user)
                {
                    case "1":
                        DisplayAll();
                        break;
                    case "2":
                        DisplayOutingsByEventType();
                        break;
                    case "3":
                        //Go back
                        displayMenu = false;
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
        private void DisplayAll()
        {
            Console.Clear();
            List<Outing> listofOutings = _repo.GetOutings();
            foreach (Outing outing in listofOutings)
            {
                DisplayOuting(outing);
            }
            double total = listofOutings.Select(l => l.EventCost).Sum();
            Console.WriteLine($"Here is the total cost of all the events: ${total}");
            AnyKey();
        }
        private void DisplayOuting(Outing outing)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Event Type: {outing.Events}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Number of people attending: {outing.NumPeople}\n" +
                           $"Date: {outing.Date.ToShortDateString()}\n" +
                           $"Total cost per person: ${outing.PersonCost}\n" +
                           $"Total cost for the event: ${outing.EventCost}\n");
        }
        private void DisplayOutingsByEventType()
        {
            bool menu = true;
            while (menu)
            {
                Console.Clear();
                Console.WriteLine("Please pick which type of outing you want to display:");
                Console.WriteLine("1. Golf\n" +
                        "2. Bowling\n" +
                        "3. Amusement Park\n" +
                        "4. Concert\n" +
                        "5. Back");
                string user = Console.ReadLine();
                switch (user)
                {
                    case "1":
                        DisplayGolf();
                        break;
                    case "2":
                        
                        DisplayBowling();
                        break;
                    case "3":
                        DisplayAmusementPark();
                        break;
                    case "4":
                        DisplayConcert();
                        break;
                    case "5":
                        //Go back
                        menu = false;
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
        private void DisplayGolf()
        {
            Console.Clear();
            List<Outing> listofEvents = _repo.GetOutingByEvent(EventType.Golf);
            
            foreach (Outing outing in listofEvents)
            {
                DisplayOuting(outing);
            }
            double total = listofEvents.Select(l => l.EventCost).Sum();
            Console.WriteLine($"Here is the total cost of all the golf events: ${total}");
            AnyKey();
        }
        private void DisplayBowling()
        {
            Console.Clear();
            List<Outing> listofEvents = _repo.GetOutingByEvent(EventType.Bowling);

            foreach (Outing outing in listofEvents)
            {
                DisplayOuting(outing);
            }
            double total = listofEvents.Select(l => l.EventCost).Sum();
            Console.WriteLine($"Here is the total cost of all the bowling events: ${total}");
            AnyKey();
        }
        private void DisplayAmusementPark()
        {
            Console.Clear();
            List<Outing> listofEvents = _repo.GetOutingByEvent(EventType.Amusement_Park);     
            foreach (Outing outing in listofEvents)
            {
                DisplayOuting(outing);  
            }
            double total = listofEvents.Select(l => l.EventCost).Sum();
            Console.WriteLine($"Here is the total cost of all the amusement park events: ${total}");
            AnyKey();
        }
        private void DisplayConcert()
        {
            Console.Clear();
            List<Outing> listofEvents = _repo.GetOutingByEvent(events: EventType.Concert);

            foreach (Outing outing in listofEvents)
            {
                DisplayOuting(outing);
            }
            double total = listofEvents.Select(l => l.EventCost).Sum();
            Console.WriteLine($"Here is the total cost of all the concert events: ${total}");
            AnyKey();
        }
        private double CalculateTotalOutingCost()
        {
            List<Outing> listofOutings = _repo.GetOutings();
            double total = listofOutings.Select(l => l.EventCost).Sum();
            return total;
        }
        private void SeedContent()
        {
            Outing golf1 = new Outing(EventType.Golf, 15, new DateTime(2022, 5, 3), 7.99, 678);
            Outing golf2 = new Outing(EventType.Golf, 54, new DateTime(2023, 2, 4), 9.99, 1243);
            Outing bowling = new Outing(EventType.Bowling, 65, new DateTime(2022, 6, 15), 10, 532);
            Outing amusementpark = new Outing(EventType.Amusement_Park, 67, new DateTime(2023, 4, 22), 12.99, 540);
            Outing concert1 = new Outing(EventType.Concert, 63, new DateTime(2022, 7, 6), 40, 777);
            Outing concert2 = new Outing(EventType.Concert, 200, new DateTime(2022, 12, 11), 50, 2000);
            _repo.AddOutingToDirectory(golf1);
            _repo.AddOutingToDirectory(golf2);
            _repo.AddOutingToDirectory(bowling);
            _repo.AddOutingToDirectory(amusementpark);
            _repo.AddOutingToDirectory(concert1);
            _repo.AddOutingToDirectory(concert2);
        }
        private void AnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
