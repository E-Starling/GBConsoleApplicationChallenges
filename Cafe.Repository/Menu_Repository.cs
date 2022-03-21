using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Repository
{
    public class MenuRepository
    {
        protected readonly List<Menu> _menuDir = new List<Menu>();
        //C
        public bool AddMenuItemToDirectory(Menu item)
        {
            int startingCount = _menuDir.Count();
            _menuDir.Add(item);
            bool wasAdded = (_menuDir.Count() > startingCount) ? true : false;
            return wasAdded;
        }
        //R
        public List<Menu> GetItems()
        {
            return _menuDir;
        }
        public Menu GetMenuItemByNum(int num)
        {
            return _menuDir.Where(i => i.MealNum == num).SingleOrDefault();
        }
        public Menu GetMenuItemByName(string name)
        {
            return _menuDir.Where(i => i.MealName == name).SingleOrDefault();
        }
        //D
        public bool DeleteExistingMenuItem(Menu existingItem)
        {
            bool deleteResult = _menuDir.Remove(existingItem);
            return deleteResult;
        }
    }
}
