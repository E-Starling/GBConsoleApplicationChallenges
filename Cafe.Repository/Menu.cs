using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Repository
{
    public class Menu
    {
        
        public Menu() { }
        public Menu(int mealNum, string mealName, string description, string ingredients, double price)
        {
            MealNum = mealNum;
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            Price = price;

        }
        public int MealNum { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }
    }
}
