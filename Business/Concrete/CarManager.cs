using Business.Abstract;
using Business.BusinessAspects;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager :ICarService
    {
        //Injection....
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            var result = BusinessRules.Run(CheckCountOfCars(car.CarName));
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        [SecuredOperation("product.add,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetByBrandID(int brandID)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(c => c.BrandID == brandID));
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetByColorID(int colorID)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(c => c.ColorID == colorID));
        }
        [CacheAspect]
        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccesDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(),Messages.CarDetailsListed);
        }
        [SecuredOperation("product.add,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        private IResult CheckCountOfCars(string carName)
        {
            var result = _carDal.GetAll(c => c.CarName == carName).Count;
            if (result > 3)
            {
                return new ErrorResult(Messages.CarCountLimitError);
            }
            return new SuccessResult();
        }
    }
}
