using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cafe.Repository;

namespace BGFinalApplicationChallenges
{
    public class ProgramUI
    {
        private MenuRepository _repo = new MenuRepository();
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
                    "3. Add Meal\n" +
                    "4. Remove Meal\n" +
                    "5. Exit");
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
                        AddMeal();
                        break;
                    case "4":
                        Remove();
                        break;
                    case "5":
                    case "e":
                    case "exit":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number from 1 to 5.");
                        AnyKey();
                        break;
                }
            }
        }
        //Create
        private void AddMeal()
        {
            bool anotherone = true;
            while (anotherone)
            {
                Console.Clear();
                Menu meal = new Menu();
                // Meal number
                bool checkingMealNum = true;
                while (checkingMealNum)
                {
                    Console.Write("Please enter an meal number for the meal: ");
                    int mealNum;
                    string user = Console.ReadLine();
                    if (!int.TryParse(user, out mealNum))
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a valid meal number!\n");
                    }
                    else
                    {
                        var existing = _repo.GetMenuItemByNum(int.Parse(user));
                        if (existing == null)
                        {
                            meal.MealNum = int.Parse(user);
                            checkingMealNum = false;
                        }
                        else
                        {
                            Console.WriteLine("That meal number is taken.");
                        }
                    }
                }
                // Meal name
                bool checkingMealName = true;
                while (checkingMealName)
                {
                    Console.Write("Please enter a meal name: ");
                    string user = Console.ReadLine();
                    var existing = _repo.GetMenuItemByName(user);
                    if (existing == null)
                    {
                        meal.MealName = user;
                        checkingMealName = false;
                    }
                    else
                    {
                        Console.WriteLine("That meal name is taken.");
                    }
                }
                // Meal description
                Console.Write("Please enter a meal description: ");
                meal.Description = Console.ReadLine();
                // Meal ingredients
                Console.Write("Please enter the meal ingredients: ");
                meal.Description = Console.ReadLine();
                // Meal price
                bool checkingMealPrice = true;
                while (checkingMealPrice)
                {
                    Console.Write("Please enter an meal price: ");
                    double mealPrice;
                    string user = Console.ReadLine();
                    if (!double.TryParse(user, out mealPrice))
                    {
                        Console.WriteLine("Please enter a valid meal price!");
                    }
                    else
                    {
                        meal.Price = double.Parse(user);
                        checkingMealPrice = false;
                    }
                }
                _repo.AddMenuItemToDirectory(meal);
                Console.WriteLine("Meal was successfuly added!");
                // Adding Multiple Meals
                Console.WriteLine("Would you like to add another meal?");
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
                        Console.WriteLine("Please enter either yes or no.");
                        AnyKey();
                        break;
                }
            }
        }
        //Read
        private void Display()
        {
            Console.Clear();
            List<Menu> listofMeals = _repo.GetItems();
            foreach (Menu meal in listofMeals)
            {
                DisplayMeal(meal);
            }
            AnyKey();
        }
        private void Search()
        {
            bool searchMenu = true;
            while (searchMenu)
            {
                Console.Clear();
                Console.WriteLine("1. Meal by meal number\n" +
                        "2. Meal by name\n" +
                        "3. Back\n");
                string user = Console.ReadLine();
                switch (user)
                {
                    case "1":
                        SearchMealByNum();
                        break;
                    case "2":
                        SearchMealByName();
                        break;
                    case "3":
                        //Go back
                        searchMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number from 1 to 3.");
                        AnyKey();
                        break;
                }
            }
        }
        private void SearchMealByNum()
        {
            Console.Clear();
            bool search = true;
            while (search)
            {
                Console.Write("Please enter an meal number of a meal you want to search for: ");
                int iD;
                string user = Console.ReadLine();
                if (!int.TryParse(user, out iD))
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a number!\n");
                }
                else
                {
                    int mealNumSearch = int.Parse(user);
                    Menu meal = _repo.GetMenuItemByNum(mealNumSearch);
                    if (meal != null)
                    {
                        DisplayMeal(meal);
                        search = false;
                    }
                    else
                    {
                        Console.WriteLine("Couldn't find a meal by that meal number");
                        search = false;
                    }
                }
            }
            AnyKey();
        }
        private void SearchMealByName()
        {
            Console.Clear();
            Console.Write("Please enter an meal name of a meal you want to search for: ");
            string user = Console.ReadLine();
            Menu meal = _repo.GetMenuItemByName(user);
            if (meal != null)
            {
                DisplayMeal(meal);
            }
            else
            {
                Console.WriteLine("Couldn't find a meal by that meal name");
            }
            AnyKey();
        }
        //Delete
        private void Remove()
        {
            bool addMenu = true;
            while (addMenu)
            {
                Console.Clear();
                Console.WriteLine("1. Remove meal by number\n" +
                        "2. Remove meal by name\n" +
                        "3. Back\n");
                string user = Console.ReadLine();
                switch (user)
                {
                    case "1":
                        RemoveMealByNum();
                        break;
                    case "2":
                        RemoveMealByName();
                        break;
                    case "3":
                        //Go back
                        addMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number from 1 to 3.");
                        AnyKey();
                        break;
                }
            }
        }
        private void RemoveMealByNum()
        {
            Console.Clear();
            bool removing = true;
            while (removing)
            {
                Console.Write("Please enter the meal number of the meal you would like to remove: ");
                int mealNum;
                string user = Console.ReadLine();
                if (!int.TryParse(user, out mealNum))
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a valid number!\n");
                }
                else
                {
                    int numSearch = int.Parse(user);
                    Menu meal = _repo.GetMenuItemByNum(numSearch);
                    if (meal != null)
                    {
                        _repo.DeleteExistingMenuItem(meal);
                        Console.WriteLine("Meal was deleted!");
                        removing = false;
                    }
                    else
                    {
                        Console.WriteLine("Couldn't find a meal by that meal number");
                        removing = false;
                    }
                }
            }
            AnyKey();
        }
        private void RemoveMealByName()
        {
            Console.Clear();
            bool removing = true;
            while (removing)
            {
                Console.Write("Please enter a name of the meal you would like to remove: ");
                string user = Console.ReadLine();
                Menu meal = _repo.GetMenuItemByName(user);
                if (meal != null)
                {
                    _repo.DeleteExistingMenuItem(meal);
                    Console.WriteLine("Meal was deleted!");
                    removing = false;
                }
                else
                {
                    Console.WriteLine("Couldn't find a meal by that name");
                    removing = false;
                }
            }
            AnyKey();
        }
        private void DisplayMeal(Menu content)
        {
            Console.WriteLine($"Meal Number: {content.MealNum}\n" +
                           $"Meal Name: {content.MealName}\n" +
                           $"Meal Description: {content.Description}\n" +
                           $"Meal Ingredients: {content.Ingredients}\n" +
                           $"Meal Price: {content.Price}\n");
        }
        private void SeedContent()
        //Adding some menu items
        {
            Menu komodoDouble = new Menu(2, "Komododouble", "Double cheeseburger with medium fries and medium drink", "Lettace, Tomato, Onion, Ketchup, Mustard, Cheese", 5.99);
            Menu komodoVeggie = new Menu(5, "Komodoveggie", "Plantbased burger with medium fries and medium drink", "Lettace, Tomato, Onion, Ketchup, Mustard", 6.99);
            Menu komodoSimple = new Menu(9, "Simple and Clean", "Large Drink and Large Fries", "Drink and Fries", 1.25);
            Menu komodoKid = new Menu(3, "Komodokid", "Single cheeseburger with small fries and small drink", "Cheese, Ketchup, Mustard", 2.99);
            _repo.AddMenuItemToDirectory(komodoDouble);
            _repo.AddMenuItemToDirectory(komodoVeggie);
            _repo.AddMenuItemToDirectory(komodoSimple);
            _repo.AddMenuItemToDirectory(komodoKid);
        }
        private void AnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
