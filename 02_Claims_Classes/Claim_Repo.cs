using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Classes
{
    public class Claim_Repo
    {
        Queue<Claim> _listOfClaims = new Queue<Claim>();
        public Queue<Claim> GetListOfClaims()
        {
            return _listOfClaims;
        }
        public bool AddClaim(Claim steal)
        {
            int startingCount = _listOfClaims.Count();
            _listOfClaims.Enqueue(steal);
            bool wasAdded = (_listOfClaims.Count > startingCount) ? true : false;
            return wasAdded;
        }
    }
}
