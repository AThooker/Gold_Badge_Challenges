using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badge_Classes
{

    public class Badge_Repository
    {
        //BadgeID = Key(int)    Door Name/Number = Value(string)
        Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();
        //Create
        public bool AddToDictionary(int x, List<string> A65)
        {
            int startingCount = _badgeDictionary.Count();
            _badgeDictionary.Add(x, A65);
            bool wasAdded = (_badgeDictionary.Count > startingCount) ? true : false;
            return wasAdded;
        }
        //Read
        public Dictionary<int, List<string>> GetList()
        {
            return _badgeDictionary;
        }
        //Update 
        public List<string> GetDoorByID(int id)
        {
            foreach (KeyValuePair<int, List<string>> badge in _badgeDictionary)
            {
                if (badge.Key == id)
                {
                    return badge.Value;
                }
            }
            return default;
        }
        //Delete 
        public bool DeleteDoorValues(int id)
        {
            List<string> getValue = GetDoorByID(id);
            foreach (string value in getValue)
            {
                bool deleteResult = getValue.Remove(value);
                return deleteResult;
            }
            return default;
        }
    }
}
