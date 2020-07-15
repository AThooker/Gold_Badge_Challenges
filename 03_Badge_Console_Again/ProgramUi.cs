using _03_Badge_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badge_Console_Again
{
    class ProgramUI
    {
        Badge_Repository _repo = new Badge_Repository();
        Dictionary<int, List<string>> _newDict = new Dictionary<int, List<string>>();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }
        public void RunMenu()
        {
            bool continueToLoop = true;
            while (continueToLoop)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin. What would you like to do?\n" +
                    "");
                Console.WriteLine("1. Add a badge\n" +
                    "\n" +
                    "2. Edit a badge\n" +
                    "\n" +
                    "3. List all badges\n" +
                    "\n" +
                    "4. Delete all door access for a badge\n" +
                    "\n" +
                    "5. Exit" +
                    "\n");
                Console.Write("Pick a number:# ");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //Add Badge
                        NewBadge();
                        break;
                    case "2":
                        //Update Badge
                        EditBadge();
                        break;
                    case "3":
                        //List Badges
                        GetList();
                        break;
                    case "4":
                        //Delete Doors from Badge
                        DeleteDoors();
                        break;
                    case "5":
                        continueToLoop = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Try again buddy");
                        break;
                }
            }
        }
        private void NewBadge()
        {
            Console.Clear();
            _newDict = new Dictionary<int, List<string>>();
            List<string> valSet = new List<string>();
            Console.Write("What is the number of the new badge?: # ");
            int key = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nList a door that it needs access to: ");
            string value = Console.ReadLine();
            valSet.Add(value);
            _repo.AddToDictionary(key, valSet);
            bool newLoop = true;
            while (newLoop)
            {
                Console.Write("\nDoes this badge need access to any other doors (y/n)?: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "y":
                        Console.Write("\nList a door that it needs access to: ");
                        string door = Console.ReadLine();
                        valSet.Add(door);
                        break;
                    case "n":
                        newLoop = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong button buddy\n");
                        break;
                }
            }
            Console.WriteLine("\nNew badge created\n" +
                "\n" +
                "Press any key to continue");
            Console.ReadKey();
        }
        private void EditBadge()
        {
            Dictionary<int, List<string>> _newDict = new Dictionary<int, List<string>>();
            Console.Clear();
            Console.Write("What is the badge number you'd like to update?: #");
            string badgeID = Console.ReadLine();
            int findID = Convert.ToInt32(badgeID);
            List<string> values = _repo.GetDoorByID(findID);
            foreach (string door in values)
            {
                Console.WriteLine($"\n#{badgeID} has access to door(s) {door}");
            }
            Console.WriteLine("\n What would you like to do?:\n" +
                "\n" +
                "1. Remove a door" +
                "\n" +
                "2. Add a door\n" +
                "\n");
            Console.Write("#");
            string answer = Console.ReadLine();
            switch (answer)
            {
                case "1":
                    Console.WriteLine("Which door would you like to remove?: ");
                    string removeDoor = Console.ReadLine();
                    values.Remove(removeDoor);
                    Console.WriteLine("Door removed");
                    foreach (string door in values)
                    {
                        Console.WriteLine($"#{badgeID} has access to door(s) {door}");
                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
                case "2":
                    Console.WriteLine("Which door would you like to add?: ");
                    string addDoor = Console.ReadLine();
                    values.Add(addDoor);
                    Console.WriteLine("\nDoor added");
                    foreach (string door in values)
                    {
                        Console.WriteLine($"#{badgeID} has access to door(s) {door}");
                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
            }
            Console.WriteLine(values);
        }
        private void GetList()
        {
            Console.Clear();
            Console.WriteLine("Badge#\t\tDoor Access\n");
            Dictionary<int, List<string>> getAll = _repo.GetList();
            foreach (KeyValuePair<int, List<string>> eachOne in getAll)
            {
                foreach (string value in eachOne.Value)
                {
                    Console.WriteLine(eachOne.Key + "\t" + " " + "\t" + value);
                }
            }
            Console.ReadKey();
        }
        private void DeleteDoors()
        {
            Console.Clear();
            Console.WriteLine("What is the number of the badge from which you'd like to remove all access?: ");
            string answer = Console.ReadLine();
            int badgeId = Convert.ToInt32(answer);
            _repo.DeleteDoorValues(badgeId);
            Console.WriteLine($"\nAccess to all doors denied for badge #{badgeId}.");
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }
        private void SeedContent()
        {
            List<string> valSetOne = new List<string>();
            valSetOne.Add("A1");
            List<string> valSetTwo = new List<string>();
            valSetTwo.Add("B2");
            _repo.AddToDictionary(1234, valSetOne);
            _repo.AddToDictionary(2234, valSetOne);
            _repo.AddToDictionary(5678, valSetTwo);
            _repo.AddToDictionary(6678, valSetTwo);
        }
    }
}
