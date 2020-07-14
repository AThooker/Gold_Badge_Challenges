using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _01_Cafe_Classes;
using System.Threading.Tasks;

namespace _01_Cafe_Console
{
    public class Cafe_ProgramUI
    {
        CafeRepo _repo = new CafeRepo();
        public void Run()
        {
            ExistingItems();
            RunMenu();
        }
        private void RunMenu()
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Hello Komodo Cafe Manager!\n" +
                "\n" +
                "How can I be of assistance?");
                Console.WriteLine("\n" +
                    "1.) I need to Add a new menu item.\n" +
                    "2.) I need to Remove a menu item.\n" +
                    "3.) I need a list of all menu items.\n" +
                    "4.) I don't need anything, get me out of here.\n" +
                    "");
                Console.Write("Type your number here, press enter, and I will get you where you need to be: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //Add
                        AddItem();
                        break;
                    case "2":
                        //Remove
                        RemoveItem();
                        break;
                    case "3":
                        //Show All
                        ListItems();
                        break;
                    case "4":
                        loop = false;
                        //Exit
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("You've entered....the Twilight Zone.....nah just kidding, just go back and make sure you enter a number ya big goof");
                        Console.ReadKey();
                        break;
                }
            }
        }


        private void ExistingItems()
        {
            Console.Clear();
            MenuItem burger = new MenuItem(1, "Big Burger", "The biggest burger in the world, maybe.", "beef, bread, cheese, lettuce, tomato, pickles", 11.50);
            MenuItem nachos = new MenuItem(2, "ZEE Nachos", "They are ZEE Best!", "tortilla chips, grilled chicken, grilled veggies, lettuce, shredded cheese, pico de gallo", 9.75);
            MenuItem corndog = new MenuItem(3, "CornDog", "I'd order two because they are that good", "deliciousness, fluffiness, hope, restoration in humanity", 5.25);
            _repo.AddMenuItem(burger);
            _repo.AddMenuItem(nachos);
            _repo.AddMenuItem(corndog);
        }

        void AddItem()
        {
            Console.Clear();
            MenuItem newFood = new MenuItem();
            Console.WriteLine("Please enter the meal number(example '5'): ");
            newFood.MealNumber = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Please enter the name of the meal (example 'The King Deluxe Super McAwesome Burger')");
            newFood.MealName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter a description of the meal (example 'If you are not hungry, do not get this massive burger')");
            newFood.Description = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter the ingredients of the item (example 'beef, tomato, pickles, onion, lettuce, etc')");
            newFood.Ingredients = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter the price (example '8.75')");
            newFood.Price = Convert.ToDouble(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("*Menu item added to list!*\n" +
                "");
            _repo.AddMenuItem(newFood);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        void RemoveItem()
        {
            Console.Clear();
            Console.WriteLine("Which item would you like to remove (by meal number)?:");
            List<MenuItem> removeItem = _repo.GetList();
            int count = 0;
            foreach (MenuItem item in removeItem)
            {
                count++;
                Console.WriteLine($"{count}, {item.MealName}");
            }
            int targetContentID = int.Parse(Console.ReadLine());
            int targetIndex = targetContentID - 1;
            if (targetIndex >= 0 && targetIndex < removeItem.Count)
            {
                MenuItem tobeRemoved = removeItem[targetIndex];
                if (_repo.DeleteExistingItem(tobeRemoved))
                {
                    Console.WriteLine($"{tobeRemoved.MealName} successfully removed.");
                }
                else
                {
                    Console.WriteLine("Nope, that isn't going to work.");
                }
            }
            else
            {
                Console.WriteLine("No content has that ID");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        void ListItems()
        {
            Console.Clear();
            List<MenuItem> menuVar = _repo.GetList();

            foreach (MenuItem food in menuVar)
            {
                DisplayContent(food);
                Console.WriteLine("------------------");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        void DisplayContent(MenuItem getAll)
        {
            Console.WriteLine($"Number: {getAll.MealNumber} \n" +
                $"Name: {getAll.MealName} \n" +
                $"Description: {getAll.Description} \n" +
                $"Ingredients: {getAll.Ingredients} \n" +
                $"Price: {getAll.Price} \n");
        }
    }
}
