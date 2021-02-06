using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.Entity_Framework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            
            Console.WriteLine("Tamamını listeleme");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + " " + car.Description);
            }
            
            Console.WriteLine("Brand Id'ye göre listeleme");
            foreach (Car car in carManager.GetAllByBrandId(1))
            {
                Console.WriteLine(car.Id + " " + car.Description);
            }
            
            Console.WriteLine("Color Id'ye göre listeleme");
            foreach (Car car in carManager.GetAllByColorId(1))
            {
                Console.WriteLine(car.Id + " " + car.Description);
            }

            Car car1 = new Car() { BrandId = 3, ColorId = 2, DailyPrice = 450, Description = "2020 Model Kırmızı Renk Wolksvagen", ModelYear = 2020 };
            carManager.Add(car1);
            Car car2 = new Car() { BrandId = 3, ColorId = 2, DailyPrice = 0, Description = "2020 Model Kırmızı Renk Wolksvagen", ModelYear = 2020 };
            carManager.Add(car2);
        }
    }
}
