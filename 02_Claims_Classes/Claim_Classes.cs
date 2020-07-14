using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Classes
{
    public enum ClaimType
    {
        Car =1,
        Home,
        Theft
    }
    public class Claim
    {
        public int ID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                TimeSpan span = DateOfClaim - DateOfIncident;
                if(span.TotalDays <= 30 && span.TotalDays >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public Claim(){}
        public Claim(int id, ClaimType typeOfClaim, string description, double amount, DateTime dateOfIncident, DateTime dateOFClaim) 
        {
            ID = id;
            TypeOfClaim = typeOfClaim;
            Description = description;
            Amount = amount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOFClaim;
        }
    }
}
