using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentCarContext>, IRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetails()
        {
            using (RentCarContext carContext = new RentCarContext())
            {
                var result = from r in carContext.Rentals
                             join c in carContext.Cars
                             on r.CarID equals c.CarID
                             join u in carContext.Users
                             on r.CustomerID equals u.UserID
                             select new RentalDetailsDto
                             {
                                 RentalID = r.RentalID,
                                 CarName = c.CarName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 DailyPrice = c.DailyPrice,
                                 Email = u.Email,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
                             
            }
        }
    }
}
