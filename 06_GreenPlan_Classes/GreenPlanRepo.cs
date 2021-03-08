using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenPlan_Classes
{
    public class GreenPlanRepo
    {
        private List<Car> _listOfCars = new List<Car>();
        public bool AddElectricCar(Car car)
        {
            int carNum = _listOfCars.Count();
            _listOfCars.Add(car);
            int newCount = _listOfCars.Count;
            bool addedOne = newCount > carNum ? true : false;
            return addedOne;
        }
        public bool AddGasCar(Car car)
        {
            int carNum = _listOfCars.Count();
            _listOfCars.Add(car);
            int newCount = _listOfCars.Count;
            bool addedOne = newCount > carNum ? true : false;
            return addedOne;
        }
        public bool AddHybrid(Car car)
        {
            int carNum = _listOfCars.Count();
            _listOfCars.Add(car);
            int newCount = _listOfCars.Count;
            bool addedOne = newCount > carNum ? true : false;
            return addedOne;
        }
        public List<Car> GetCars()
        {
            return _listOfCars;
        }
        public Car GetByName(string name)
        {
            foreach(var car in _listOfCars)
            {
                if (name == car.Name)
                {
                    return car;
                }
                else
                    return null;
            }
            return null;
        }
        public bool DeleteCar(string name)
        {
            int firstCount = _listOfCars.Count();
            foreach(var car in _listOfCars)
            {
                if(name == car.Name)
                {
                    _listOfCars.Remove(car);
                }
            }
            int secondCount = _listOfCars.Count();
            bool deleted = firstCount > secondCount ? true : false;
            return deleted;
        }
    }
}
