using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (RentCarContext carContext = new RentCarContext())
            {
                var addedCar = carContext.Entry(entity);
                addedCar.State = EntityState.Added;
                carContext.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (RentCarContext carContext = new RentCarContext())
            {
                var deletedCar = carContext.Entry(entity);
                deletedCar.State = EntityState.Deleted;
                carContext.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RentCarContext carContext = new RentCarContext())
            {
                return carContext.Set<Car>().SingleOrDefault(filter); 
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentCarContext carContext = new RentCarContext())
            {
                return filter == null ?
                    carContext.Set<Car>().ToList() : carContext.Set<Car>().Where(filter).ToList(); 
            }
        }

        public void Update(Car entity)
        {
            using (RentCarContext carContext = new RentCarContext())
            {
                var updatedCar = carContext.Entry(entity);
                updatedCar.State = EntityState.Modified;
                carContext.SaveChanges();
            }
        }
    }
}
