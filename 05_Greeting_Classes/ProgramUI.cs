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
            while (continueToRun)
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
                string input = Console.ReadLine();
                int num = Convert.ToInt32(input);
                switch (num)
                {
                    case 1:
                        GetListOfCustomers();
                        break;
                    case 2:
                        AddCustomer();
                        break;
                    case 3:
                        UpdateCustomer();
                        break;
                    case 4:
                        DeleteCustomer();
                        break;
                    case 5:
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Pick a number");
                        break;
                }
            }
        }
        public void GetListOfCustomers()
        {
            Console.Clear();
            Console.WriteLine($"{ "Firstname"}\t{"Lastname"}\t{"Customer Type"}\t{"Email"}");
            Console.WriteLine("---------------------------------------------------------------");
            List<Customer> custList = _repo.GetCustomers();
            foreach (var cust in custList)
            {
                DisplayCust(cust);
                Console.WriteLine("---------------------------------------------------------");
            }
            Console.ReadKey();
        }
        private void AddCustomer()
        {
            Console.Clear();
            Customer customer = new Customer();
            Console.WriteLine("What is the customer's first name?: \n");
            customer.FirstName = Console.ReadLine();
            Console.WriteLine("What is the customer's last name?: \n");
            customer.LastName = Console.ReadLine();
            Console.WriteLine("Are they a 1. Current, 2. Past, or 3. Potential customer?: \n");
            string custType = Console.ReadLine();
            int custEnum = int.Parse(custType);
            customer.Type = (CustomerType)custEnum;
            _repo.AddCustomer(customer);
        }
        private void UpdateCustomer()
        {
            Console.Clear();
            GetListOfCustomers();
            Console.Write("\n Which customer would you like to update? (enter their first name): ");
            string name = Console.ReadLine().ToLower();
            Console.Clear();
            Customer cust = _repo.GetCustomerByName(name);
            Console.WriteLine($"{ "Firstname"}\t{"Lastname"}\t{"Customer Type"}\t");
            Console.WriteLine("---------------------------------------------------------------");
            string values = String.Format("{0,-10}\t{1, -10}\t{2,-15}", cust.FirstName, cust.LastName, cust.Type.ToString());
            Console.WriteLine(values);
            Console.WriteLine("Firstname: \n");
            cust.FirstName = Console.ReadLine();
            Console.WriteLine("Lastname: \n");
            cust.LastName = Console.ReadLine();
            Console.WriteLine("Type: ");
            string custType = Console.ReadLine();
            cust.Type = (CustomerType)Enum.Parse(typeof(CustomerType), custType);
            Console.ReadKey();
        }
        private void DeleteCustomer()
        {

        }
        private void DisplayCust(Customer cust)
        {
            if (cust.Type == CustomerType.Current)
            {
                var email = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                string values = String.Format("{0,-10}\t{1, -10}\t{2,-15} {3,10}", cust.FirstName, cust.LastName, cust.Type.ToString(), email);
                Console.WriteLine(values);
            }
            else if (cust.Type == CustomerType.Past)
            {
                var email = "It's been a long time since we've heard from you, we want you back";
                string values = String.Format("{0,-10}\t{1, -10}\t{2,-15} {3,10}", cust.FirstName, cust.LastName, cust.Type.ToString(), email);
                Console.WriteLine(values);
            }
            else if (cust.Type == CustomerType.Potential)
            {
                var email = "We currently have the lowest rates on Helicopter Insurance!";
                string values = String.Format("{0,-10}\t{1, -10}\t{2,-15} {3,10}", cust.FirstName, cust.LastName, cust.Type.ToString(), email);
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
