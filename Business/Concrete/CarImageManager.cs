using Business.Abstract;
using Business.BusinessAspects;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarService _carService;
        public CarImageManager(ICarImageDal carImageDal,ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;

        }
        [SecuredOperation("carImage.add,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfImagesCount(carImage.CarID));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.AddAsync(file);
            carImage.ImageDate = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }
        [SecuredOperation("carImage.delete,admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImage carImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) +
                _carImageDal.Get(p => p.ImageID == carImage.ImageID).ImagePath;

            IResult result = BusinessRules.Run(
                FileHelper.DeleteAsync(oldpath));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccesDataResult<List<CarImage>>( _carImageDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<List<CarImage>> GetByCarID(int carID)
        {
            var result = BusinessRules.Run(CheckIfCarImageNull(carID));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }
            return new SuccesDataResult<List<CarImage>>(CheckIfCarImageNull(carID).Data);
        }
        [CacheAspect]
        public IDataResult<CarImage> GetID(int imageID)
        {
            return new SuccesDataResult<CarImage>(_carImageDal.Get(c=>c.ImageID==imageID));
        }
        [SecuredOperation("carImage.update,admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) +
                _carImageDal.Get(p => p.ImageID == carImage.ImageID).ImagePath;
            carImage.ImagePath = FileHelper.UpdateAsync(oldpath, file);
            carImage.ImageDate = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }
               
        private IResult CheckIfImagesCount(int carID)
        {
            var result = _carImageDal.GetAll(c=> c.CarID == carID).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.NumberOfImagesLimitError);
            }
            return new SuccessResult();

        }
        private IDataResult<List<CarImage>> CheckIfCarImageNull(int carID)
        {
            try
            {
                string path = @"\Images\default.jpg";
                var result = _carImageDal.GetAll(c => c.CarID == carID).Any();
                if (!result)
                {
                    List<CarImage> carimage = new List<CarImage>();
                    carimage.Add(new CarImage { CarID = carID, ImagePath = path, ImageDate = DateTime.Now });
                    return new SuccesDataResult<List<CarImage>>(carimage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            return new SuccesDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarID == carID).ToList());
        }

        
    }
}
