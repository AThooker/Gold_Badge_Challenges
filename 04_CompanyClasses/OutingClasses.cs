using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_CompanyClasses
{
    public enum EventType { Golf, Bowling, AmusementPark, Concert };
    public class Outing
    {
        public EventType EventType { get; set; }
        public int Attendance { get; set; }
        public DateTime DateOfEvent { get; set; }
        public double CostPerPerson { get; set; }
        public double CostForEvent { get; set; }

        public Outing() { }
        public Outing ( EventType eventType, int attendance, DateTime dateOfEvent, double costPerPerson, double costForEvent)
        {
            EventType = eventType;
            Attendance = attendance;
            DateOfEvent = dateOfEvent;
            CostPerPerson = costPerPerson;
            CostForEvent = costForEvent;
        }
    }

}
