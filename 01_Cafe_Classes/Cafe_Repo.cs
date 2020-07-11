using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Classes
{   
    public class CafeRepo
    {
        //List of menu items (field)
        List<MenuItem> _listOfItems = new List<MenuItem>();
        //Add to List
        public bool AddMenuItem(MenuItem food)
        {
            int startingCount = _listOfItems.Count();
            _listOfItems.Add(food);
            bool wasAdded = (_listOfItems.Count > startingCount) ? true : false;
            return wasAdded;
        }
        //Get List
        public List<MenuItem> GetList()
        {
            return _listOfItems;
        }
        //Delete
        public bool DeleteExistingItem(MenuItem existingContent)
        {
            bool deleteResult = _listOfItems.Remove(existingContent);
            return deleteResult;
        }
    }

}
