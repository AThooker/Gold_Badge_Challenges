using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Greeting_Class
{
    public enum CustomerType { Past, Current, Potential = 3 }
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType Type { get; set; }
        public Customer() { }
        public Customer(string firstName, string lastName, CustomerType type)
        {
            FirstName = firstName;
            LastName = lastName;
            Type = type;
        }
    }
}
