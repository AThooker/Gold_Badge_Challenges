using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_CompanyClasses
{
    public class OutingRepo
    {
        List<Outing> _outings = new List<Outing>();

        public List<Outing> GetListOfOutings()
        {
            return _outings;
        }
        public bool AddToList(Outing outing)
        { 
                int startingCount = _outings.Count();
                _outings.Add(outing);
                bool wasAdded = (_outings.Count > startingCount) ? true : false;
                return wasAdded;
            
        }
    }
}
