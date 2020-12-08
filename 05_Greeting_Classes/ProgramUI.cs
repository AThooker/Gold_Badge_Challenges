using _05_Greeting_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Greeting_Classes
{
    public class ProgramUI
    {
        Greeting_Repo _repo = new Greeting_Repo();
        public void Run()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            SeedContent();
            RunMenu();
        }
        public void RunMenu()
        {
            bool continueToRun = true;
            while(continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Hi Mr/Mrs administrator, what can I do for you today?\n" +
                    "\n" +
                    "1. See full list of customers\n" +
                    "\n" +
                    "2. Add a customer\n" +
                    "\n" +
                    "3. Update a customer\n" +
                    "\n" +
                    "4. Delete customer\n" +
                    "\n" +
                    "5. Exit");
            }
            string input = Console.ReadLine();
            int num = Convert.ToInt32(input);
            switch(num)
            {
                case 1:
                    GetListOfCustomers();
                    break;
            }
        }
        public void GetListOfCustomers()
        {
            Console.Clear();
            Console.WriteLine($"{ "Firstname"}\t{"Lastname"}\t{"Customer Type"}\t{"Email"}");
            List<Customer> custList = _repo.GetCustomers();
            foreach(var cust in custList)
            {
                DisplayCust(cust);
                Console.WriteLine("---------------------------------------------------------");
            }
        }
        private void DisplayCust(Customer cust)
        {
            if(cust.Type == CustomerType.Current)
            {
                var email = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                string values = String.Format("{0,-10}\t{1, 4}\t{2,15} {3,10}", cust.FirstName, cust.LastName, cust.Type, email);
                Console.WriteLine(values);
            }
            else if(cust.Type == CustomerType.Past)
            {
                var email = "It's been a long time since we've heard from you, we want you back";
                string values = String.Format("{0,-10}\t{1, 4}\t{2,15} {3,10}", cust.FirstName, cust.LastName, cust.Type, email);
                Console.WriteLine(values);
            }
            else if(cust.Type == CustomerType.Potential)
            {
                var email = "We currently have the lowest rates on Helicopter Insurance!";
                string values = String.Format("{0,-10}\t{1, 4}\t{2,15} {3,10}", cust.FirstName, cust.LastName, cust.Type, email);
                Console.WriteLine(values);
            }
        }
        private void SeedContent()
        {
            Customer one = new Customer("Bill", "Shaky", CustomerType.Current);
            Customer two = new Customer("Bob", "Evans", CustomerType.Past);
            Customer three = new Customer("O", "Charley's", CustomerType.Potential);

            _repo.AddCustomer(one);
            _repo.AddCustomer(two);
            _repo.AddCustomer(three);
        }
    }
}
