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
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            SeedContent();
            RunMenu();
        }
        public void RunMenu()
        {
            bool continueRun = true;
            while (continueRun)
            {
                Console.WriteLine("Hi mr/mrs accountant, what can I do for you today?\n" +
                    "\n" +
                    "1. See full list of outings\n" +
                    "\n" +
                    "2. Add an outing to the list\n" +
                    "\n" +
                    "3. See total cost of outings.\n" +
                    "\n" +
                    "4. See total cost of outings by type.\n" +
                    "");

                string resp = Console.ReadLine();
                int numResp = Convert.ToInt32(resp);
                switch (numResp)
                {
                    case 1:
                        //Get List of Outings
                        GetListOutings();
                        break;
                //    case 2:
                //        //Add Outing to list
                //        AddToOutings();
                //        break;
                //
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
        private void DisplayOutings(Outing outing)
        {
            string values = String.Format("{0,-10}\t{1, 4}\t{2,15} {3,10} {4,15}", outing.EventType, outing.Attendance, outing.DateOfEvent.ToString("dd/MM/yyyy"), outing.CostPerPerson, outing.CostForEvent);
            Console.WriteLine(values);

            //Console.WriteLine($"{outing.EventType}\t\t{outing.Attendance}\t{outing.DateOfEvent.Date}\t\t{outing.CostPerPerson}\t\t{outing.CostForEvent}");
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
