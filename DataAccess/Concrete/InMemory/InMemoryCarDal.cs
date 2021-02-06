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
        List<Car> _cars = new List<Car>
        {
            new Car{Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 150, ModelYear = 2010, Description = "2010 Model Wolksvagen  Otomobil." },
            new Car{Id = 2, BrandId = 1, ColorId = 2, DailyPrice = 200, ModelYear = 2013, Description = "2013 Model Wolksvagen  Otomobil." },
            new Car{Id = 3, BrandId = 2, ColorId = 4, DailyPrice = 300, ModelYear = 2017, Description = "2017 Model BMW" },
            new Car{Id = 4, BrandId = 3, ColorId = 3, DailyPrice = 250, ModelYear = 2014, Description = "2014 Model Mercedes" }
        };
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = null;
            carToDelete = _cars.SingleOrDefault(p=>p.Id == carToDelete.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
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

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(p => p.Id == brandId).ToList();

        }

        public void Update(Car car)
        {
            Car carToUpdate = null;
            carToUpdate = _cars.SingleOrDefault(p => p.Id == carToUpdate.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
            
        }
    }
}
