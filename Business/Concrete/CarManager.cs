using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
        public void Add(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Ürün ekleyebilmek için ürünün adı 2 karakterden uzun olmalı ve günlük fiyatı 0'dan büyük olmalıdır. Bu yüzden ekleyemezsiniz.");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

       

        public void Update(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Update(car);
            }
            else
            {
                Console.WriteLine("Ürün güncelleyebilmek için ürünün adı 2 karakterden uzun olmalı ve günlük fiyatı 0'dan büyük olmalıdır. Bu yüzden güncelleyemezsiniz.");
            }
        }

        public List<Car> GetAllByBrandId(int brandId)
        {
            return _carDal.GetAll(p=>p.BrandId == brandId);
        }

        public List<Car> GetAllByColorId(int colorId)
        {
            return _carDal.GetAll(p => p.ColorId == colorId);
        }
    }
}
