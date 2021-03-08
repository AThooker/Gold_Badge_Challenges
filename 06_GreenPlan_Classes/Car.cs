using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenPlan_Classes
{
    public enum Type { Electric, Gas, Hybrid}
    public class Car
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Type Type { get; set; }
    }
}
