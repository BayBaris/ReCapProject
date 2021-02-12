using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                new Car{CarID = 1,BrandID = 1,ColorID = 1,ModelYear = "2019",DailyPrice = 200,Descriptions = "Tesla Model S"},
                new Car{CarID = 2,BrandID = 2,ColorID = 2,ModelYear = "2014",DailyPrice = 600,Descriptions = "BMW Elytra"},
                new Car{CarID = 3,BrandID = 3,ColorID = 3,ModelYear = "2013",DailyPrice = 1400,Descriptions = "Lamborghini Sesto Elemento"},
                new Car{CarID = 4,BrandID = 1,ColorID = 2,ModelYear = "2016",DailyPrice = 400,Descriptions = "Tesla Model Y"},
                new Car{CarID = 5,BrandID = 2,ColorID = 1,ModelYear = "2020",DailyPrice = 1200,Descriptions = "BMW M5"},
                new Car{CarID = 6,BrandID = 2,ColorID = 4,ModelYear = "2019",DailyPrice = 800,Descriptions = "BMW Seuzki"},
                new Car{CarID = 7,BrandID = 3,ColorID = 4,ModelYear = "2019",DailyPrice = 2500,Descriptions = "Lamborghini Egoist"},
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

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
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
            updatedcar.Descriptions = car.Descriptions;
        }
    }
}
