using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Claims.Repository;

namespace Claims.Program
{
    public class ProgramUI
    {
        private ClaimsRepo _repo = new ClaimsRepo();
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
                Console.WriteLine("Chose a menu item:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");
                string user = Console.ReadLine();
                switch (user)
                {
                    case "1":
                        Display();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        AddClaim();
                        break;
                    case "4":
                    case "e":
                    case "exit":
                        continueToRun = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid number from 1 to 4.");
                        Console.ForegroundColor = ConsoleColor.White;
                        AnyKey();
                        break;
                }
            }
        }
        //Create
        private void AddClaim()
        {
            bool anotherone = true;
            while (anotherone)
            {
                Console.Clear();
                Claim claim = new Claim();
                //(int iD, ClaimType claim, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
                // ID
                bool checkingiD = true;
                while (checkingiD)
                {
                    Console.Write("Enter the claim id: ");
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
                        var existing = _repo.GetClaimById(int.Parse(user));
                        if (existing == null)
                        {
                            claim.ID = int.Parse(user);
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
                // ClaimType
                bool checkingEventType = true;
                while (checkingEventType)
                {
                    Console.WriteLine("Please pick a claim type:\n" +
                        "1. Car\n" +
                        "2. Home\n" +
                        "3. Theft");
                    string user = Console.ReadLine();
                    switch (user)
                    {
                        case "1":
                            claim.Claims = ClaimType.Car;
                            checkingEventType = false;
                            break;
                        case "2":
                            claim.Claims = ClaimType.Home;
                            checkingEventType = false;
                            break;
                        case "3":
                            claim.Claims = ClaimType.Theft;
                            checkingEventType = false;
                            break;  
                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please enter a valid number from 1 to 3.\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                // Description
                Console.Write("Enter a claim description: ");
                string description = Console.ReadLine();
                claim.Description = description;
                // ClaimAmount
                bool checkingClaimAmount = true;
                while (checkingClaimAmount)
                {
                    Console.Write("Amount of Damage: ");
                    double claimAmount;
                    string user = Console.ReadLine();
                    if (!double.TryParse(user, out claimAmount))
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a number!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        claim.ClaimAmount = double.Parse(user);
                        checkingClaimAmount = false;
                    }
                }
                // Date of Incident
                bool checkingDateIncident = true;
                while (checkingDateIncident)
                {
                    Console.Write("Date Of Accident (YYYY,MM,DD): ");
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
                        claim.DateOfIncident = DateTime.Parse(user);
                        checkingDateIncident = false;
                    }
                }
                // Date of Claim
                bool checkingDateClaim= true;
                while (checkingDateClaim)
                {
                    Console.Write("Date Of Claim (YYYY,MM,DD): ");
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
                        claim.DateOfClaim = DateTime.Parse(user);
                        checkingDateClaim = false;
                    }
                }
                // IsValid
                DateTime incidents = claim.DateOfIncident;
                DateTime claims = claim.DateOfClaim;
                TimeSpan valid = claims - incidents;
                double totalDays = valid.TotalDays;
                if (totalDays > 30)
                {
                    claim.IsValid = false;
                }
                else
                {
                    claim.IsValid = true;
                }
                _repo.AddClaimToDirectory(claim);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Claim was successfuly added!");
                Console.ForegroundColor = ConsoleColor.White;
                // Adding Multiple Claims
                Console.WriteLine("Would you like to add another claim?");
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
            Console.Clear();
            Console.WriteLine("ClaimID          Car         Description         Amount          DateofAccident          DateOfClaim         IsValid");
            List<Claim> listofClaims = _repo.GetClaims();
            foreach (Claim claim in listofClaims)
            {
                DisplayClaim(claim);
            }
            AnyKey();
        }
        private void DisplayClaim(Claim claim)
        {
                Console.WriteLine($"{claim.ID}              {claim.Claims}         {claim.Description}         {claim.ClaimAmount}" +
                    $"         {claim.DateOfIncident.ToShortDateString()}         {claim.DateOfClaim.ToShortDateString()}         {claim.IsValid}");
        }
        
        //Update and Delete
        private void NextClaim()
        {
            bool nextClaim = true;
            List<Claim> listofClaims = _repo.GetClaims();
                while (nextClaim)
                {
                    foreach (Claim claim in listofClaims)
                    {
                        Console.Clear();
                        DisplayClaimNext(claim);
                        Console.WriteLine("Do you want to deal with this claim now?");
                        Console.WriteLine("1. yes\n" +
                            "2. no");
                        string userinput = Console.ReadLine();
                        switch (userinput)
                        {
                            case "1":
                            case "yes":
                            case "y":
                                Claim claims = _repo.GetClaimById(claim.ID);
                                _repo.DeleteExistingClaim(claims);

                                break;
                            case "2":
                            case "no":
                            case "n":
                                //Go Back to main menu
                                nextClaim = false;
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Please enter either yes or no.");
                                Console.ForegroundColor = ConsoleColor.White;
                                AnyKey();
                                break;
                        }
                        break;
                    }
            }        
        }
        private void DisplayClaimNext(Claim claim)
        {
            Console.WriteLine($"ClaimID: {claim.ID}\n" +
                $"Type: {claim.Claims}\n" +
                $"Description: {claim.Description}\n" +
                $"Amount: {claim.ClaimAmount}\n" +
                $"DateOfAccident: {claim.DateOfIncident}\n" +
                $"DateOfClaim: {claim.DateOfClaim}\n" +
                $"IsValid: {claim.IsValid}");
        }
        private void SeedContent()
        {
            Claim car1 = new Claim(1, ClaimType.Car, "Car accident on 420.", 230, new DateTime(2020, 2, 3), new DateTime(2022, 3, 1), false);
            Claim car2 = new Claim(2, ClaimType.Car, "Meteor hit car.", 30000, new DateTime(2021, 5, 4), new DateTime(2021, 5, 9), true);
            Claim home = new Claim(3, ClaimType.Home, "House caught on fire.", 90000, new DateTime(2019, 2, 3), new DateTime(2019, 3, 1), true);
            Claim theft1 = new Claim(4, ClaimType.Theft, "Stolen lego set.", 6500, new DateTime(2022, 3, 2), new DateTime(2022, 3, 5), true);
            Claim theft2 = new Claim(5, ClaimType.Theft, "Stolen infinity gauntlet.", 3, new DateTime(2009, 12, 2), new DateTime(2022, 1, 20), false);
            _repo.AddClaimToDirectory(car1);
            _repo.AddClaimToDirectory(car2);
            _repo.AddClaimToDirectory(home);
            _repo.AddClaimToDirectory(theft1);
            _repo.AddClaimToDirectory(theft2);
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

