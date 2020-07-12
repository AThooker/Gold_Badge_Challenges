using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Classes
{
    public class Claim_Repo
    {
        List<Claim> _listOfClaims = new List<Claim>();

        public List<Claim> GetListOfClaims()
        {
            return _listOfClaims;
        }

        public Claim GetClaimByID(int id)
        {
            foreach(Claim file in _listOfClaims)
            {
                if(file.ID == id)
                {
                    return file;
                }
            }
            return null;
        }
        public bool AddClaim(Claim steal)
        {
            int startingCount = _listOfClaims.Count();
            _listOfClaims.Add(steal);
            bool wasAdded = (_listOfClaims.Count > startingCount) ? true : false;
            return wasAdded;
        }
    }
}
