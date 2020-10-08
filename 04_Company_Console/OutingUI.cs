using _04_CompanyClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Company_Console
{
    public class OutingUI
    {
        OutingRepo _repo = new OutingRepo();
        public void Run()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            SeedContent();
            RunMenu();
        }
        public void RunMenu()
        {
            bool continueRun = true;
            while (continueRun)
            {
                Console.Clear();
                Console.WriteLine("Hi mr/mrs accountant, what can I do for you today?\n" +
                    "\n" +
                    "1. See full list of outings\n" +
                    "\n" +
                    "2. Add an outing to the list\n" +
                    "\n" +
                    "3. See total cost of outings.\n" +
                    "\n" +
                    "4. See total cost of outings by type.\n" +
                    "\n" +
                    "5. Exit");

                string resp = Console.ReadLine();
                int numResp = Convert.ToInt32(resp);
                switch (numResp)
                {
                    case 1:
                        //Get List of Outings
                        GetListOutings();
                        break;
                    case 2:
                        //Add Outing to list
                        AddToOutings();
                        break;
                    case 3:
                        //Cost of All Outings
                        CostOfAllOutings();
                        break;
                    case 4:
                        //Cost by type
                        CostByType();
                        break;
                    case 5:
                        continueRun = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Try again buddy");
                        break;
                }
            }
        }
        private void GetListOutings()
        {
            Console.Clear();
            Console.WriteLine($"{ "Event Type"}\t{"Attendance"}\t{"Date"}\t{"Cost/Person"}\t{"Cost/Event"}");
            List<Outing> outings = _repo.GetListOfOutings();
            foreach (var item in outings)
            {
                DisplayOutings(item);
                Console.WriteLine("---------------------------------------------------------");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private void AddToOutings()
        {
            Outing oneEvent = new Outing();
            List<Outing> outings = new List<Outing>();
            Console.Clear();
            Console.Write("Is the event a Golf, Bowling, AmusementPark, or Concert event?:\n ");
            string type = Console.ReadLine();
            int enumID = Convert.ToInt32(type);
            oneEvent.EventType = (EventType)enumID;
            Console.Write("How many people will be attending?:\n");
            string att = Console.ReadLine();
            int attendance = Convert.ToInt32(att);
            oneEvent.Attendance = attendance;
            Console.Write("What is the date of the event? (ex. dd/mm/yyyy): \n");
            string date = Console.ReadLine();
            DateTime dateTime = Convert.ToDateTime(date);
            oneEvent.DateOfEvent = dateTime;
            Console.Write("What is the cost per person?: \n");
            string costPerson = Console.ReadLine();
            double costPerPerson = Convert.ToDouble(costPerson);
            oneEvent.CostPerPerson = costPerPerson;
            Console.Write("What is the total cost of the event?: \n");
            string cost = Console.ReadLine();
            double costEvent = Convert.ToDouble(cost);
            oneEvent.CostForEvent = costEvent;
            _repo.AddToList(oneEvent);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private void CostOfAllOutings()
        {
            Console.Clear();
            List<Outing> outings = _repo.GetListOfOutings();
            double total = outings.Sum(p => p.CostForEvent);
            Console.WriteLine($"The total cost of events is: ${total} ");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private void CostByType()
        {
            Console.Clear();
            List<Outing> outings = _repo.GetListOfOutings();

            double golfTotal = outings.Where(p => p.EventType == 0).Sum(p => p.CostForEvent);
            Console.WriteLine($"The total cost of Golf events is: ${golfTotal}\n");

            double bowlingTotal = outings.Where(p => p.EventType == (EventType)1).Sum(p => p.CostForEvent);
            Console.WriteLine($"The total cost of Bowling events is: ${bowlingTotal}\n");

            double parkTotal = outings.Where(p => p.EventType == (EventType)2).Sum(p => p.CostForEvent);
            Console.WriteLine($"The total cost of Amusement Park events is: ${parkTotal}\n");

            double concertTotal = outings.Where(p => p.EventType == (EventType)3).Sum(p => p.CostForEvent);
            Console.WriteLine($"The total cost of Concert events is: ${concertTotal}\n");

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private void DisplayOutings(Outing outing)
        {
            string values = String.Format("{0,-10}\t{1, 4}\t{2,15} {3,10} {4,15}", outing.EventType, outing.Attendance, outing.DateOfEvent.ToString("dd/MM/yyyy"), outing.CostPerPerson, outing.CostForEvent);
            Console.WriteLine(values);
        }
        private void SeedContent()
        {
            Outing one = new Outing(EventType.Bowling, 40, new DateTime(2020, 01, 06), 15.50, 300);
            Outing two = new Outing(EventType.Concert, 76, new DateTime(2019, 09, 23), 25.45, 2000);
            Outing three = new Outing(EventType.Golf, 12, new DateTime(2020, 06, 17), 45, 500);
            Outing four = new Outing(EventType.AmusementPark, 33, new DateTime(2019, 08, 05), 60.50, 150);

            _repo.AddToList(one);
            _repo.AddToList(two);
            _repo.AddToList(three);
            _repo.AddToList(four);
        }
    }
}
