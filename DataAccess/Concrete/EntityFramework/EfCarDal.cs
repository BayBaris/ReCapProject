using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (RentCarContext carContext = new RentCarContext())
            {
                //Cars tablosunu önce Brands tablosu ile aradından da Colors tablosu ile ilişkilendirerek daha sonrasında ise...
                //...CarDetailsDto nesnemizin içindeki değerler ile ilişkilendirdik...
                var result = from c in carContext.Cars
                             join b in carContext.Brands
                             on c.BrandID equals b.BrandID
                             join cl in carContext.Colors
                             on c.ColorID equals cl.ColorID
                             select new CarDetailsDto
                             {
                                 CarName = c.CarName,
                                 ColorName = cl.ColorName,
                                 BrandName = b.BrandName,
                                 CarID = c.CarID,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 Descriptions = c.Descriptions
                             };
                return result.ToList();
                            
            }
        }
    }
}
