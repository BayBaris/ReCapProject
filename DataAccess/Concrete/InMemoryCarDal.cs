using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car{CarID = 1,BrandID = 1,ColorID = 1,ModelYear = 2019,DailyPrice = 200,Description = "Tesla Model S"},
                new Car{CarID = 2,BrandID = 2,ColorID = 2,ModelYear = 2014,DailyPrice = 600,Description = "BMW Elytra"},
                new Car{CarID = 3,BrandID = 3,ColorID = 3,ModelYear = 2013,DailyPrice = 1400,Description = "Lamborghini Sesto Elemento"},
                new Car{CarID = 4,BrandID = 1,ColorID = 2,ModelYear = 2016,DailyPrice = 400,Description = "Tesla Model Y"},
                new Car{CarID = 5,BrandID = 2,ColorID = 1,ModelYear = 2020,DailyPrice = 1200,Description = "BMW M5"},
                new Car{CarID = 6,BrandID = 2,ColorID = 4,ModelYear = 2019,DailyPrice = 800,Description = "BMW Seuzki"},
                new Car{CarID = 7,BrandID = 3,ColorID = 4,ModelYear = 2019,DailyPrice = 2500,Description = "Lamborghini Egoist"},
            };
        }
        public void Add(Car car)
        {           
            _cars.Add(car);
            
        }

        public void Delete(Car car)
        {
            Car deletedcars = _cars.SingleOrDefault(c => c.CarID == car.CarID);
            _cars.Remove(deletedcars);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetByCarId(int brandID)
        {
            return _cars.Where(c => c.BrandID == brandID).ToList();
        }

        public void Update(Car car)
        {
            Car updatedcar = _cars.SingleOrDefault(c => c.CarID == car.CarID);
            
            updatedcar.BrandID = car.BrandID;
            updatedcar.ColorID = car.ColorID;
            updatedcar.DailyPrice = car.DailyPrice;
            updatedcar.ModelYear = car.ModelYear;
            updatedcar.Description = car.Description;
        }
    }
}
